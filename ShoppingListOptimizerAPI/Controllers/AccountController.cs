using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShoppingListOptimizerAPI.Business.JWTInfrastructure;
using ShoppingListOptimizerAPI.Business.Services;
using ShoppingListOptimizerAPI.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace ShoppingListOptimizerAPI.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;

        private readonly ILogger<AccountController> _logger;
        private readonly AccountService _accountService;
        private readonly IJwtAuthManager _jwtAuthManager;

        public AccountController(ILogger<AccountController> logger, AccountService accountService,
            IJwtAuthManager jwtAuthManager, UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            _logger = logger;
            _accountService = accountService;
            _jwtAuthManager = jwtAuthManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Route("myprofile")]
        public ActionResult GetMyProfile()
        {
            var userName = User.Identity?.Name;
            /*if (userName.Length > 0)
            {
                var user = _userService.GetMyProfile(userName);
                if (user != null)
                {
                    return new ObjectResult(user);
                }
            }*/
            return new ObjectResult(userName);
            //return NotFound();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            // Validate and create a new user
            var user = new Account { UserName = request.UserName, Email = request.Email, Description = "..." };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                return Ok(new { Message = "Registration successful" });
            }

            return BadRequest("Registration failed");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (result.Succeeded)
            {
                //var token = GenerateJwtToken(request.UserName); // Implement this method
                //var role = _accountService.GetUserRole(request.UserName);
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, request.UserName)/*,
                new Claim(ClaimTypes.Role, role)*/};

                var token = _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);
                return Ok(new { Token = token });
            }

            return BadRequest("Login failed");
        }





        /*
        [AllowAnonymous]
        [HttpPost("edit")]
        public ActionResult Edit([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var validUser = _userService.IsValidUserCredentials(request.UserName, request.Password);
            if (validUser == null)
            {
                return Unauthorized();
            }
            
            
            JsonSerializer s = new JsonSerializer();
            Location l = s.Deserialize<Location>(new JsonTextReader(new StringReader(request.Location)));

            
            
            Profile user = new Profile()
            {
                Email = request.Email,
                Password = request.Password,
                Currency = request.Currency,
                Location = l,
                UserName = request.UserName
            };

            Profile editedProfile = _userService.EditProfile(user, validUser.Id);
            if (editedProfile != null)
            {
                return new ObjectResult(editedProfile);
            }
            
            return BadRequest();
        }*/

        [HttpGet("user")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            var c = User.Claims;
            await _userManager.AddToRoleAsync(user, "User");
            var roles = await _userManager.GetRolesAsync(user);
            return Ok(new LoginResult
            {
                UserName = User.Identity?.Name,
                Role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty,
                OriginalUserName = User.FindFirst("OriginalUserName")?.Value
            });
        }

        /*[HttpPost("logout")]
        [Authorize]
        public ActionResult Logout()
        {
            // optionally "revoke" JWT token on the server side --> add the current token to a block-list
            // https://github.com/auth0/node-jsonwebtoken/issues/375

            var userName = User.Identity?.Name;
            _jwtAuthManager.RemoveRefreshTokenByUserName(userName);
            _logger.LogInformation($"User [{userName}] logged out the system.");
            return Ok();
        }*/

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var userName = User.Identity?.Name;
            _jwtAuthManager.RemoveRefreshTokenByUserName(userName);
            await HttpContext.SignOutAsync();
            return Ok();
        }

        [HttpPost("refresh-token")]
        [Authorize]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var userName = User.Identity?.Name;
                _logger.LogInformation($"User [{userName}] is trying to refresh JWT token.");

                if (string.IsNullOrWhiteSpace(request.RefreshToken))
                {
                    return Unauthorized();
                }

                var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
                var jwtResult = _jwtAuthManager.Refresh(request.RefreshToken, accessToken, DateTime.Now);
                _logger.LogInformation($"User [{userName}] has refreshed JWT token.");
                return Ok(new LoginResult
                {
                    UserName = userName,
                    Role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty,
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                });
            }
            catch (SecurityTokenException e)
            {
                return
                    Unauthorized(e.Message); // return 401 so that the client side can redirect the user to login page
            }
        }
        /*
        [HttpPost("impersonation")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult Impersonate([FromBody] ImpersonationRequest request)
        {
            var userName = User.Identity?.Name;
            _logger.LogInformation($"User [{userName}] is trying to impersonate [{request.UserName}].");

            var impersonatedRole = _userService.GetUserRole(request.UserName);
            if (string.IsNullOrWhiteSpace(impersonatedRole))
            {
                _logger.LogInformation(
                    $"User [{userName}] failed to impersonate [{request.UserName}] due to the target user not found.");
                return BadRequest($"The target user [{request.UserName}] is not found.");
            }

            if (impersonatedRole == UserRoles.Admin)
            {
                _logger.LogInformation($"User [{userName}] is not allowed to impersonate another Admin.");
                return BadRequest("This action is not supported.");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.UserName),
                new Claim(ClaimTypes.Role, impersonatedRole),
                new Claim("OriginalUserName", userName ?? string.Empty)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);
            _logger.LogInformation($"User [{request.UserName}] is impersonating [{request.UserName}] in the system.");
            return Ok(new LoginResult
            {
                UserName = request.UserName,
                Role = impersonatedRole,
                OriginalUserName = userName,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        [HttpPost("stop-impersonation")]
        public ActionResult StopImpersonation()
        {
            var userName = User.Identity?.Name;
            var originalUserName = User.FindFirst("OriginalUserName")?.Value;
            if (string.IsNullOrWhiteSpace(originalUserName))
            {
                return BadRequest("You are not impersonating anyone.");
            }

            _logger.LogInformation($"User [{originalUserName}] is trying to stop impersonate [{userName}].");

            var role = _userService.GetUserRole(originalUserName);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, originalUserName),
                new Claim(ClaimTypes.Role, role)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(originalUserName, claims, DateTime.Now);
            _logger.LogInformation($"User [{originalUserName}] has stopped impersonation.");
            return Ok(new LoginResult
            {
                UserName = originalUserName,
                Role = role,
                OriginalUserName = null,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }
    }
        */
        public class LoginRequest
        {
            [Required]
            [JsonPropertyName("username")]
            public string UserName { get; set; }

            [Required]
            [JsonPropertyName("password")]
            public string Password { get; set; }
        }

        public class RegisterRequest
        {
            [Required]
            [JsonPropertyName("username")]
            public string UserName { get; set; }

            [Required]
            [JsonPropertyName("password")]
            public string Password { get; set; }

            [Required][JsonPropertyName("email")] public string Email { get; set; }

            /*[Required]
            [JsonPropertyName("location")]
            public string Location { get; set; }*/
        }


        public class LoginResult
        {
            [JsonPropertyName("username")] public string UserName { get; set; }

            [JsonPropertyName("role")] public string Role { get; set; }

            [JsonPropertyName("originalUserName")] public string OriginalUserName { get; set; }

            [JsonPropertyName("accessToken")] public string AccessToken { get; set; }

            [JsonPropertyName("refreshToken")] public string RefreshToken { get; set; }

            [JsonPropertyName("email")] public string Email { get; set; }

            //[JsonPropertyName("location")] public string Location { get; set; }

            //[JsonPropertyName("currency")] public string Currency { get; set; }
        }

        public class RefreshTokenRequest
        {
            [JsonPropertyName("refreshToken")] public string RefreshToken { get; set; }
        }

        public class ImpersonationRequest
        {
            [JsonPropertyName("username")] public string UserName { get; set; }
        }
    }
}

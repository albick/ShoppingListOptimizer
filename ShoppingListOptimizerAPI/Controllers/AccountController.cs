using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShoppingListOptimizerAPI.Business.JWTInfrastructure;
using ShoppingListOptimizerAPI.Business.Services;
using ShoppingListOptimizerAPI.Data.Models;
using ShoppingListOptimizerAPI.Requests;
using ShoppingListOptimizerAPI.Responses;
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


        [HttpGet("user")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            var c = User.Claims;
            await _userManager.AddToRoleAsync(user, "User");
            var roles = await _userManager.GetRolesAsync(user);
            return Ok(new LoginResponse
            {
                UserName = User.Identity?.Name,
                Role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty,
                OriginalUserName = User.FindFirst("OriginalUserName")?.Value
            });
        }


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
                return Ok(new LoginResponse
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



        


        

        

        
    }
}

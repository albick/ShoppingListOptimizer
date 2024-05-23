using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShoppingListOptimizerAPI.Business.DTOs;
using ShoppingListOptimizerAPI.Business.JWTInfrastructure;
using ShoppingListOptimizerAPI.Business.Services;
using ShoppingListOptimizerAPI.Data.Models;
using ShoppingListOptimizerAPI.Models.Requests;
using ShoppingListOptimizerAPI.Models.Responses;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace ShoppingListOptimizerAPI.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;

        private readonly ILogger<AccountsController> _logger;
        private readonly AccountService _accountService;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly IMapper _mapper;

        public AccountsController(ILogger<AccountsController> logger, AccountService accountService,
            IJwtAuthManager jwtAuthManager, UserManager<Account> userManager, SignInManager<Account> signInManager, IMapper mapper)
        {
            _logger = logger;
            _accountService = accountService;
            _jwtAuthManager = jwtAuthManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        /*[Authorize]
        [HttpGet]
        [Route("myprofile")]
        public ActionResult GetMyProfile()
        {
            var userName = User.Identity?.Name;
            if (userName.Length > 0)
            {
                var user = _userService.GetMyProfile(userName);
                if (user != null)
                {
                    return new ObjectResult(user);
                }
            }
            return new ObjectResult(userName);
            return NotFound();
        }*/

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            Account user = new Account { UserName = request.UserName, Email = request.Email };
            bool result = _accountService.RegisterUser(user, request.Password).Result;
            if (result)
            {
                RegisterResponse response = new RegisterResponse();
                response.Message = "Registration successful";
                return Ok(response);
            }

            return BadRequest("Registration failed");
        }

        [AllowAnonymous]
        [HttpPost("register-shop")]
        public async Task<IActionResult> RegisterShop([FromBody] RegisterShopRequest request)
        {
            Account user = new Account { UserName = request.Company, Email = request.Email };
            bool result = _accountService.RegisterShop(user, request.Password,
                request.Location.city,
                request.Location.postcode,
                request.Location.street,
                request.Location.number,
                request.Location.latitude,
                request.Location.longitude
                ).Result;
            if (result)
            {
                RegisterResponse response = new RegisterResponse();
                response.Message = "Registration successful";
                return Ok(response);
            }

            return BadRequest("Registration failed");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = this._accountService.Login(request.Email, request.Password);
            if (result.Result != null)
            {
                if (result.Result.Succeeded)
                {
                    var user = _accountService.GetUserByEmail(request.Email).Result;
                    if (result != null)
                    {
                        var roles = await _accountService.GetUserRoleByEmail(request.Email);
                        var claims = new List<Claim>        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName)        };

                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role)); // Add each role as a claim
                        }
                        var _claims = claims.ToArray();

                        

                        var token = _jwtAuthManager.GenerateTokens(user.UserName, _claims, DateTime.Now);
                        JwtAuthResponse response = new JwtAuthResponse { AccessToken = token.AccessToken, RefreshToken = token.RefreshToken,Roles=roles.ToArray() };
                        return Ok(response);
                    }
                }
                return BadRequest("Login failed");
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

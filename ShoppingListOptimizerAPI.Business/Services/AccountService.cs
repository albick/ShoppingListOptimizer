
using Microsoft.AspNetCore.Identity;
using ShoppingListOptimizerAPI.Business.DTOs;
using ShoppingListOptimizerAPI.Business.JWTInfrastructure;
using ShoppingListOptimizerAPI.Data.Infrastructure;
using ShoppingListOptimizerAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ShoppingListOptimizerAPI.Business.Services
{
    public class AccountService
    {
        private readonly MyDbContext _context;
        private readonly SignInManager<Account> _signInManager;
        private readonly UserManager<Account> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(MyDbContext context,
            SignInManager<Account> signInManager,
            UserManager<Account> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> RegisterUser(Account account, string password)
        {

            var result = await _userManager.CreateAsync(account, password);
            if (result.Succeeded)
            {
                var user = GetUserByEmail(account.Email).Result;
                await _userManager.AddToRoleAsync(user, "User");
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> RegisterShop(Account account, string password,
            string city,
            string postcode,
            string street,
            string number,
            double latitude,
            double longitude
            )
        {

            account.Location = new Location()
            {
                City = city,
                Postcode = postcode,
                Street = street,
                Number = number,
                Latitude = latitude,
                Longitude = longitude
            };
            var result = await _userManager.CreateAsync(account, password);

            if (result.Succeeded)
            {
                var user = GetUserByEmail(account.Email).Result;
                await _userManager.AddToRoleAsync(user, "Shop");
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<SignInResult?> Login(string email, string password)
        {
            var user = GetUserByEmail(email);
            var result = await _signInManager.PasswordSignInAsync(user.Result.UserName, password, false, false);
            return result;
        }

        public async Task<Account> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IList<string>> GetUserRoleByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var role = await _userManager.GetRolesAsync(user);
            return role;
        }

        public async Task<Account?> GetCompanyById(string id)
        {
            var account = _userManager.FindByIdAsync(id).Result;
            if (account != null)
            {
                var roles = await _userManager.GetRolesAsync(account);
                if (roles.Contains("Shop"))
                {
                    return account;
                }
                else { return null; }
            }
            return null;
        }

        public async Task<Account?> GetUserById(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("User"))
                {
                    return user;
                }
                else { return null; }
            }
            return null;
        }

        public async Task<Account?> GetCurrentUser()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var user = _userManager.FindByIdAsync(userId).Result;
                if (user != null)
                {
                    return user;
                }
                return null;
            }
            return null;
        }

    }
}

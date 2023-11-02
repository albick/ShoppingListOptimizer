
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

namespace ShoppingListOptimizerAPI.Business.Services
{
    public class AccountService
    {
        private readonly MyDbContext _context;
        private readonly SignInManager<Account> _signInManager;
        private readonly UserManager<Account> _userManager;

        public AccountService(MyDbContext context, SignInManager<Account> signInManager, UserManager<Account> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> RegisterUser(Account account,string password) {

            var result = await _userManager.CreateAsync(account, password);
            if(result.Succeeded)
            {
                var user = GetUserByEmail(account.Email).Result;
                await _userManager.AddToRoleAsync(user, "User");
                return true;
            } else
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
            
            account.Location= new Location()
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
            var user=GetUserByEmail(email);
            var result = await _signInManager.PasswordSignInAsync(user.Result.UserName, password, false, false);
            return result;
        }

        public async Task<Account> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IList<string>> GetUserRoleByEmail(string email)
        {
            var user=await _userManager.FindByEmailAsync(email);
            var role=await _userManager.GetRolesAsync(user);
            return role;
        }

    }
}

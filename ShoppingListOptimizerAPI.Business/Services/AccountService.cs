using ShoppingListOptimizerAPI.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Business.Services
{
    public class AccountService
    {
        private readonly MyDbContext _context;

        public AccountService(MyDbContext context)
        {
            _context = context;
        }

        /*public Account RegisterAccount(Account account) { 
        
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return account;
        }

        public Account IsValidUserCredentials(string userName, string password)
        {
            if (userName == null || password == null)
            {
                return null;
            }
            Account account = _context.Accounts
                .SingleOrDefault(a => a.UserName == userName && a.Password == password);
            return account;
        }*/

    }
}

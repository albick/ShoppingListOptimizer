using AutoMapper;
using ShoppingListOptimizerAPI.Business.DTOs;
using ShoppingListOptimizerAPI.Data.Infrastructure;
using ShoppingListOptimizerAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Business.Services
{
    public class DbSeedService
    {
        private readonly AccountService _accountService;
        private readonly ShopService _shopService;
        private readonly ItemService _itemService;
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public DbSeedService(AccountService accountService, MyDbContext context, ShopService shopService, ItemService itemService, IMapper mapper)
        {
            _accountService = accountService;
            _shopService = shopService;
            _itemService = itemService;
            _context = context;
            _mapper = mapper;
        }
        public async Task SeedDbAsync()
        {
            #region Locations
            Location location1 = new Location
            {
                Id = 10,
                City = "Budapest",
                Postcode = "1124",
                Street = "Thomán István utca",
                Number = "9a",
                Latitude = 47.4958804,
                Longitude = 19.000898951
            };
            Location location2 = new Location
            {//óbuda lidl
                Id = 20,
                City = "Budapest",
                Postcode = "1039",
                Street = "Szentendrei út",
                Number = "251-253",
                Latitude = 47.580543500000005,
                Longitude = 19.048403359644762
            };
            Location location3 = new Location
            {//érd lidl
                Id = 30,
                City = "Érd",
                Postcode = "2030",
                Street = "Diósdi út",
                Number = "2-4",
                Latitude = 47.37926395,
                Longitude = 18.92367770850208
            };

            if (!_context.Locations.Any())
            {
                _context.Locations.AddRange(location1, location2, location3);
                _context.SaveChanges();
            }
            #endregion


            #region Accounts
            Account account1 = new Account();
            Account account2 = new Account();

            if (!_context.Accounts.Any())
            {
                bool a1 = _accountService.RegisterUser(new Account { UserName = "User1", Email = "xdd@user.com" }, "Jelszo12.").Result;
                if (a1)
                {
                    account1 = _accountService.GetUserByName("User1").Result;
                }
                bool a2 = _accountService.RegisterShop(new Account { UserName = "Shop1", Email = "xdd@shop.com" }, "Jelszo12.", location1.City, location1.Postcode, location1.Street, location1.Number, location1.Latitude, location1.Longitude).Result;
                if (a2)
                {
                    account2 = _accountService.GetUserByName("Shop1").Result;
                }
            }
            else
            {
                account1 = _accountService.GetUserByName("User1").Result;
                account2 = _accountService.GetUserByName("Shop1").Result;
            }
            #endregion


            #region Shops
            ShopDTO shop1 = new ShopDTO
            {
                Company = _mapper.Map<AccountDTO>(account2),
                Name = "Óbuda LIDL",
                Details = "...",
                Location = _mapper.Map<LocationDTO>(location2)
            };
            ShopDTO shop2 = new ShopDTO
            {
                Company = _mapper.Map<AccountDTO>(account2),
                Name = "Érd LIDL",
                Details = "...",
                Location = _mapper.Map<LocationDTO>(location3)
            };

            if (!_context.Shops.Any())
            {
                shop1 = _shopService.AddShopDevelopment(shop1, account2);
                shop2 = _shopService.AddShopDevelopment(shop2, account2);
            }
            else
            {
                shop1 = _shopService.GetShopByNameDevelopment(shop1.Name);
                shop2 = _shopService.GetShopByNameDevelopment(shop2.Name);
            }
            #endregion

            //ItemDTO item1=

        }
    }
}

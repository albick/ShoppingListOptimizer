using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppingListOptimizerAPI.Business.DTOs;
using ShoppingListOptimizerAPI.Business.Helpers;
using ShoppingListOptimizerAPI.Data.Infrastructure;
using ShoppingListOptimizerAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ShoppingListOptimizerAPI.Business.Services
{
    public class ShopService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly AccountService _accountService;

        public ShopService(MyDbContext context, IMapper mapper, AccountService accountService)
        {
            _context = context;
            _mapper = mapper;
            _accountService = accountService;
        }

        public List<ShopDTO> GetShops(double distance, string name)
        {
            double[] coordinates = _accountService.GetCurrentLocation().Result;

            List<Shop>? shops;
            if (name != null)
            {
                shops = _context.Shops.Where(s => s.Name.Contains(name))
                .Include(s => s.Creator)
                    .ThenInclude(c => c.Location)
                .Include(s => s.Company)
                    .ThenInclude(c => c.Location)
                .Include(s => s.Location)
                .Include(s => s.OpeningHours)
                .ToList();
            }
            else
            {
                shops = _context.Shops
                .Include(s => s.Creator)
                    .ThenInclude(c => c.Location)
                .Include(s => s.Company)
                    .ThenInclude(c => c.Location)
                .Include(s => s.Location)
                .Include(s => s.OpeningHours)
                .ToList();
            }


            //if distance param exists
            List<ShopDTO> shops_mapped = _mapper.Map<List<ShopDTO>>(shops);

            List<ShopDTO> shops_ret = new List<ShopDTO>();

            foreach (var s in shops_mapped)
            {
                double calculated_distance = GeoFunctions.CalculateDistance(coordinates[0], coordinates[1], s.Location.Latitude, s.Location.Longitude);
                s.DistanceFromUser = calculated_distance;
                if (!distance.Equals(0))
                {
                    if (distance >= calculated_distance)
                    {
                        shops_ret.Add(s);
                    }
                }
                else
                {
                    shops_ret.Add(s);
                }
            }






            return shops_ret;
        }

        public ShopDTO GetShopById(int id)
        {
            double[] coordinates = _accountService.GetCurrentLocation().Result;

            var shop = _context.Shops
                .Include(s => s.Creator)
                    .ThenInclude(c => c.Location)
                .Include(s => s.Company)
                    .ThenInclude(c => c.Location)
                .Include(s => s.Location)
                .Include(s => s.OpeningHours)
                .FirstOrDefault(p => p.Id == id);

            var shop_mapped = _mapper.Map<ShopDTO>(shop);

            double calculated_distance = GeoFunctions.CalculateDistance(coordinates[0], coordinates[1], shop.Location.Latitude, shop.Location.Longitude);
            shop_mapped.DistanceFromUser = calculated_distance;

            return shop_mapped;
        }

        public ShopDTO UpdateShopById(ShopDTO shop, int id)
        {
            var shopFromDb = _context.Shops
                .Include(s => s.Creator)
                    .ThenInclude(c => c.Location)
                .Include(s => s.Company)
                    .ThenInclude(c => c.Location)
                .Include(s => s.Location)
                .Include(s => s.OpeningHours)
                .FirstOrDefault(p => p.Id == id);
            if (shopFromDb != null)
            {
                var currentUser = _accountService.GetCurrentUser().Result;
                if (currentUser != null)
                {
                    if (shopFromDb.Company.Id.Equals(currentUser.Id))
                    {
                        var shopUpdated = _mapper.Map<Shop>(shop);
                        shopFromDb.OpeningHours = shopUpdated.OpeningHours;
                        shopFromDb.Name = shopUpdated.Name;
                        shopFromDb.Details = shopUpdated.Details;
                        shopFromDb.Location = shopUpdated.Location;


                        _context.Shops.Update(shopFromDb);
                    }
                }
            }
            return null;
        }

        public bool DeleteShopById(int id)
        {
            var shopFromDb = _context.Shops
                .Include(s => s.Creator)
                    .ThenInclude(c => c.Location)
                .Include(s => s.Company)
                    .ThenInclude(c => c.Location)
                .Include(s => s.Location)
                .Include(s => s.OpeningHours)
                .FirstOrDefault(p => p.Id == id);
            if (shopFromDb != null)
            {
                _context.Shops.Remove(shopFromDb);
                return true;
            }
            return false;
        }

        public ShopDTO AddShop(ShopDTO shop)
        {
            //look up company by id
            var company = _accountService.GetCompanyByName(shop.Company.UserName).Result;
            //get and look up creator by id
            var creator = _accountService.GetCurrentUser().Result;

            //link company to shop
            //link creator to shop
            var _shop = _mapper.Map<Shop>(shop);
            if (company != null && creator != null)
            {
                _shop.Creator = creator;
                _shop.Company = company;
            }
            else { return null; }

            //add to db
            _context.Shops.Add(_shop);
            _context.SaveChanges();
            return _mapper.Map<ShopDTO>(_shop);
        }

        public ShopDTO AddShopDevelopment(ShopDTO shop, Account creator)
        {

            var existingLocation = _context.Locations.Where(l => l.Id.Equals(shop.Location.Id)).FirstOrDefault();

            //look up company by id
            var company = _accountService.GetCompanyByName(shop.Company.UserName).Result;

            //link company to shop
            //link creator to shop
            var _shop = _mapper.Map<Shop>(shop);
            if (existingLocation != null)
            {
                _shop.Location = existingLocation;
            }
            if (company != null && creator != null)
            {
                _shop.Creator = creator;
                _shop.Company = company;
            }
            else { return null; }

            //add to db
            _context.Shops.Add(_shop);
            _context.SaveChanges();
            return _mapper.Map<ShopDTO>(_shop);
        }

        public ShopDTO GetShopByNameDevelopment(string name)
        {
            var shop = _context.Shops.Where(s => s.Name.Equals(name))
                .Include(s => s.Company)
                .ThenInclude(c => c.Location)
                .Include(s => s.Creator)
                .ThenInclude(c => c.Location)
                .Include(s => s.Location)
                .Include(s => s.OpeningHours)
                .FirstOrDefault();
            if (shop != null)
            {
                return _mapper.Map<ShopDTO>(shop);
            }
            return null;
        }

        public double GetMaxShopDistance()
        {
            double[] userLocation = _accountService.GetCurrentLocation().Result;
            double maxDistance = 0;
            var shops = _context.Shops.Include(shop => shop.Location).ToList();
            foreach (var shop in shops)
            {
                double distance = GeoFunctions.CalculateDistance(shop.Location.Latitude, shop.Location.Longitude, userLocation[0], userLocation[1]);
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                }
            }
            return maxDistance;
        }

        public bool IsShopOpenNow(ShopDTO shop)
        {
            if (shop.OpeningHours == null)
            {
                return true;
            }
            else
            {
                if (shop.OpeningHours.Count.Equals(0))
                {
                    return true;
                }
            }
            var now = DateTime.Now.TimeOfDay;
            var today = DateTime.Now.DayOfWeek;

            var openingHoursToday = shop.OpeningHours?.FirstOrDefault(oh => oh.DayOfWeek == today);

            if (openingHoursToday != null)
            {
                return now >= openingHoursToday.StartTime && now <= openingHoursToday.EndTime;
            }

            return false;
        }
    }
}

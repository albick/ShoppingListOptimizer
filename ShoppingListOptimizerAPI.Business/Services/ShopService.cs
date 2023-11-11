using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public List<ShopDTO> GetShops(double distance)
        {
            var geolocation = _accountService.GetCurrentLocation().Result;
            double[] coordinates= { 0, 0 };
            if (geolocation != null)
            {
                coordinates = geolocation
                    .Split(' ')[1]
                    .Split(';')
                    .Select(double.Parse)
                    .ToArray();
            }
            var shops = _context.Shops
                .Include(s => s.Creator)
                    .ThenInclude(c => c.Location)
                .Include(s => s.Company)
                    .ThenInclude(c => c.Location)
                .Include(s => s.Location)
                .ToList();

            if (!distance.Equals(0))
            {
                //if distance param exists
                //var user = _accountService.GetCurrentUser().Result;

                List<Shop> shops_ = new List<Shop>();
                foreach (var s in shops)
                {
                    if (distance <= GeoFunctions.CalculateDistance(coordinates[0], coordinates[1], s.Location.Longitude, s.Location.Latitude)) { }
                    shops_.Add(s);
                }
                shops = shops_;

            }


            List<ShopDTO> _shops = _mapper.Map<List<ShopDTO>>(shops);
            return _shops;
        }

        public ShopDTO GetShopById(int id)
        {
            var shop = _context.Shops
                .Include(s => s.Creator)
                    .ThenInclude(c => c.Location)
                .Include(s => s.Company)
                    .ThenInclude(c => c.Location)
                .Include(s => s.Location)
                .Include(s => s.OpeningHours)
                .FirstOrDefault(p => p.Id == id);
            return _mapper.Map<ShopDTO>(shop);
        }

        public ShopDTO AddShopCommunity(ShopDTO shop)
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

            //add to db
            _context.Shops.Add(_shop);
            _context.SaveChanges();
            return _mapper.Map<ShopDTO>(_shop);
        }
    }
}

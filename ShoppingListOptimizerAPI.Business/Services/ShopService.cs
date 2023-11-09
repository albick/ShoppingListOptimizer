﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingListOptimizerAPI.Business.DTOs;
using ShoppingListOptimizerAPI.Business.Helpers;
using ShoppingListOptimizerAPI.Data.Infrastructure;
using ShoppingListOptimizerAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<ShopDTO> GetShops(double? distance)
        {
            var shops = _context.Shops
                .Include(s => s.Creator)
                    .ThenInclude(c => c.Location)
                .Include(s => s.Company)
                    .ThenInclude(c => c.Location)
                .Include(s => s.Location)
                .ToList();

            if (distance.HasValue)
            {
                //if distance param exists
                var user = _accountService.GetCurrentUser().Result;
                if (user != null && user.Location != null)
                {
                    List<Shop> shops_ = new List<Shop>();
                    foreach (var s in shops)
                    {
                        if (distance <= GeoFunctions.CalculateDistance(user.Location.Longitude, user.Location.Latitude, s.Location.Longitude, s.Location.Latitude)) { }
                        shops_.Add(s);
                    }
                    shops = shops_;
                }
            }


            List<ShopDTO> _shops = _mapper.Map<List<ShopDTO>>(shops);
            return _shops;
        }

        public ShopDTO GetShopById(int id)
        {
            return _mapper.Map<ShopDTO>(_context.Shops.FirstOrDefault(p => p.Id == id));
        }

        public ShopDTO AddShopCommunity(ShopDTO shop)
        {
            //look up company by id
            var company = _accountService.GetCompanyById(shop.Company.Id).Result;
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

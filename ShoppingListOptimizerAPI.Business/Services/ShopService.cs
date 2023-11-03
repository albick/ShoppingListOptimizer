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
    public class ShopService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public ShopService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ShopDTO> GetAll()
        {
            var shops = _context.Shops.ToList();
            List<ShopDTO> _shops = _mapper.Map<List<ShopDTO>>(shops);
            return _shops;
        }

        public ShopDTO GetShopById(int id)
        {
            return _mapper.Map<ShopDTO>(_context.Shops.FirstOrDefault(p => p.Id ==id));
        }
        
        public Item AddShopCommunity(Item item)
        {
            _context.Shops.Add(item);
            _context.SaveChanges();
            return item;
        }
    }
}

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
    public class ItemService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public ItemService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ItemDTO> GetAll()
        {
            var items = _context.Items.ToList();
            List<ItemDTO> _items = _mapper.Map<List<ItemDTO>>(items);
            return _items;
        }

        public Item GetById(int id)
        {
            return _context.Items.FirstOrDefault(p => p.Id == id);
        }

        public Item Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool Update(int id, Item updatedItem)
        {
            var existingItem = _context.Items.FirstOrDefault(p => p.Id == id);
            if (existingItem == null)
                return false;

            existingItem.Name = updatedItem.Name;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var item = _context.Items.FirstOrDefault(p => p.Id == id);
            if (item == null)
                return false;

            _context.Items.Remove(item);
            _context.SaveChanges();
            return true;
        }
    }
}

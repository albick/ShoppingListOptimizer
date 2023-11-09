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

        public ItemDTO GetById(string barcode)
        {
            var item= _context.Items.FirstOrDefault(p => p.Barcode.Equals(barcode));
            return _mapper.Map<ItemDTO>(item);
        }

        public ItemDTO Create(ItemDTO item)
        {
            _context.Items.Add(_mapper.Map<Item>(item));
            _context.SaveChanges();
            return item;
        }

        public bool Update(string barcode, ItemDTO updatedItem)
        {
            var existingItem = _context.Items.FirstOrDefault(p => p.Barcode.Equals(barcode));
            if (existingItem == null)
                return false;

            existingItem.Name = updatedItem.Name;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(string barcode)
        {
            var item = _context.Items.FirstOrDefault(p => p.Barcode.Equals(barcode));
            if (item == null)
                return false;

            _context.Items.Remove(item);
            _context.SaveChanges();
            return true;
        }
    }
}

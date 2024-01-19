using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingListOptimizerAPI.Business.DTOs;
using ShoppingListOptimizerAPI.Data.Infrastructure;
using ShoppingListOptimizerAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShoppingListOptimizerAPI.Business.Services
{
    public class ItemService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly AccountService _accountService;
        private readonly ShopService _shopService;

        public ItemService(MyDbContext context, IMapper mapper, AccountService accountService, ShopService shopService)
        {
            _context = context;
            _mapper = mapper;
            _accountService = accountService;
            _shopService = shopService;
        }

        public List<ItemDTO> GetItems(double? distance, string? name, double? priceMin, double? priceMax)
        {
            var items = _context.Items.ToList();
            List<ItemDTO> _items = _mapper.Map<List<ItemDTO>>(items);
            return _items;
        }

        public ItemDTO GetByBarcode(string barcode)
        {
            var item = _context.Items.FirstOrDefault(p => p.Barcode.Equals(barcode));
            return _mapper.Map<ItemDTO>(item);
        }

        public ItemDTO Create(ItemDTO item)
        {
            //get and look up creator by id
            var creator = _accountService.GetCurrentUser().Result;
            //link creator to item
            var _item = _mapper.Map<Item>(item);
            if (creator != null)
            {
                _item.Creator = creator;
                _context.Items.Add(_item);
                _context.SaveChanges();
                return _mapper.Map<ItemDTO>(_item);
            }
            else
            {
                return null;
            }
        }

        public ItemPriceEntryDTO CreateItemPriceEntry(string barcode, int shopId, double price)
        {

            //get creator by id
            var creator = _accountService.GetCurrentUser().Result;
            //get shop by id
            var shop = _shopService.GetShopById(shopId);
            //get item by id
            var item = GetByBarcode(barcode);
            //get creation time
            DateTime currentTime = DateTime.Now;

            if (creator != null && shop != null && item != null)
            {
                // Create a detached entity for ItemPriceEntry
                var itemPriceEntryDTO = new ItemPriceEntryDTO
                {
                    CreatedAt = currentTime,
                    Price = price,
                    Shop = shop,
                    Creator = creator,
                    Item = item
                };

                var itemPriceEntryEntity = _mapper.Map<ItemPriceEntry>(itemPriceEntryDTO);

                // Explicitly mark the entity as Added, as we're attaching it to the context
                _context.Entry(itemPriceEntryEntity).State = EntityState.Added;

                // SaveChanges will add the entity to the database
                _context.SaveChanges();

                // Now, the entity is tracked, and you can retrieve its ID
                var newItemPriceEntryDTO = _mapper.Map<ItemPriceEntryDTO>(itemPriceEntryEntity);

                return newItemPriceEntryDTO;
            }
            else
            {
                return null;
            }
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

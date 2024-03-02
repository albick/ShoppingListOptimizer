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

namespace ShoppingListOptimizerAPI.Business.Services
{
    public class ShoppingListService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly AccountService _accountService;


        public ShoppingListService(MyDbContext context, IMapper mapper, AccountService accountService)
        {
            _context = context;
            _mapper = mapper;
            _accountService = accountService;
        }

        public ShoppingListDTO AddShoppingList(ShoppingListDTO shoppingListDTO)
        {
            //get creator by id
            var creator = _accountService.GetCurrentUser().Result;
            //get creation time
            DateTime currentTime = DateTime.Now;

            var _shoppingList = _mapper.Map<ShoppingList>(shoppingListDTO);

            if (creator != null)
            {
                _shoppingList.Creator = creator;
                _shoppingList.DateModified = currentTime;

                _context.ShoppingLists.Add(_shoppingList);
                _context.SaveChanges();

                return _mapper.Map<ShoppingListDTO>(_shoppingList);
            }
            return null;
        }

        public ShoppingListDTO UpdateShoppingList(ShoppingListDTO shoppingListDTO, int id)
        {
            var shoppingListFromDb = _context.ShoppingLists
                .Where(l => l.Id.Equals(id))
                .Include(l => l.ShoppingListItems)
                .ThenInclude(li => li.Item)
                .Include(l => l.Creator)
                .ThenInclude(c => c.Location)
                .FirstOrDefault();

            if (shoppingListFromDb == null)
            {
                return null;
            }
            shoppingListFromDb.DateModified = DateTime.Now;
            shoppingListFromDb.Name = shoppingListDTO.Name;
            shoppingListFromDb.Details = shoppingListDTO.Details;

            ShoppingList modifiedList = _context.ShoppingLists.Update(shoppingListFromDb).Entity;
            _context.SaveChanges();

            return _mapper.Map<ShoppingListDTO>(modifiedList);
        }

        public bool DeleteShoppingList(int listId)
        {
            var list = _context.ShoppingLists.FirstOrDefault(l => l.Id.Equals(listId));

            if (list == null)
            {
                return false;
            }
            //cascade needeed?
            _context.ShoppingLists.Remove(list);
            _context.SaveChanges();
            return true;
        }

        public ShoppingListDTO GetShoppingList(int listId)
        {
            return null;
        }
        public List<ShoppingListDTO> GetShoppingLists()
        {
            return null;
        }


        public bool DeleteShoppingListItem(int itemId)
        {
            return true;
        }

        public ShoppingListItemDTO AddShoppingListItem(ShoppingListItemDTO listItem, int listId)
        {
            var shoppingListFromDb = _context.ShoppingLists
                .Where(l => l.Id.Equals(listId))
                .Include(l => l.ShoppingListItems)
                .ThenInclude(li => li.Item)
                .Include(l => l.Creator)
                .ThenInclude(c => c.Location)
                .FirstOrDefault();

            var item = _context.Items.Where(i => i.Barcode.Equals(listItem.Item.Barcode)).FirstOrDefault();

            if (shoppingListFromDb == null)
            {
                return null;
            }
            if (item == null)
            {
                return null;
            }

            

            shoppingListFromDb.DateModified = DateTime.Now;

            var mappedListItem = _mapper.Map<ShoppingListItem>(listItem);
            mappedListItem.Item = item;
            if (shoppingListFromDb.ShoppingListItems.Count > 0)
            {
                var alreadyContains = shoppingListFromDb.ShoppingListItems.Where(li => li.Item.Barcode.Equals(listItem.Item.Barcode)).FirstOrDefault();
                if (alreadyContains != null)
                {
                    shoppingListFromDb.ShoppingListItems.Remove(alreadyContains);
                    alreadyContains.Count = listItem.Count;
                    shoppingListFromDb.ShoppingListItems.Add(alreadyContains);
                }
                else
                {
                    
                    shoppingListFromDb.ShoppingListItems.Add(mappedListItem);
                }
            }
            else
            {
                shoppingListFromDb.ShoppingListItems = new List<ShoppingListItem> { mappedListItem };
            }

            _context.ShoppingLists.Update(shoppingListFromDb);
            _context.SaveChanges();



            return _mapper.Map<ShoppingListItemDTO>(mappedListItem);
        }

        public ShoppingListItemDTO UpdateShoppingListItem(ShoppingListItemDTO listItem, int itemId, int listId)
        {
            var shoppingListFromDb = _context.ShoppingLists
                .Where(l => l.Id.Equals(listId))
                .Include(l => l.ShoppingListItems)
                .ThenInclude(li => li.Item)
                .Include(l => l.Creator)
                .ThenInclude(c => c.Location)
                .FirstOrDefault();




            if (shoppingListFromDb == null)
            {
                return null;
            }



            var listItemFromDb = _context.ShoppingListItems.Where(li => li.Id.Equals(itemId)).FirstOrDefault();
            if (listItemFromDb == null)
            {
                return null;
            }
            listItemFromDb.Count = listItem.Count;

            

            shoppingListFromDb.DateModified = DateTime.Now;



            var alreadyContains = shoppingListFromDb.ShoppingListItems.Where(li => li.Item.Barcode.Equals(listItemFromDb.Item.Barcode)).FirstOrDefault();
            if (alreadyContains != null)
            {
                shoppingListFromDb.ShoppingListItems.Remove(alreadyContains);
                shoppingListFromDb.ShoppingListItems.Add(listItemFromDb);
            }
            else
            {
                return null;
            }



            _context.ShoppingLists.Update(shoppingListFromDb);
            _context.SaveChanges();



            return _mapper.Map<ShoppingListItemDTO>(listItemFromDb);
        }
    }
}

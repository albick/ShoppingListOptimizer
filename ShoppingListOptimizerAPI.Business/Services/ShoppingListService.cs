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
            var creator = _accountService.GetCurrentUser().Result;
            var shoppingListFromDb = _context.ShoppingLists
                .Where(l => l.Id.Equals(id) && l.Creator.Id.Equals(creator.Id))
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
            var creator = _accountService.GetCurrentUser().Result;
            var list = _context.ShoppingLists.Where(l => l.Id.Equals(listId) && l.Creator.Id.Equals(creator.Id)).Include(l => l.ShoppingListItems).FirstOrDefault();

            if (list == null)
            {
                return false;
            }
            //cascade needeed

            var listItems = list.ShoppingListItems;
            if (listItems != null)
            {
                _context.ShoppingListItems.RemoveRange(listItems);
                _context.SaveChanges();
            }

            _context.ShoppingLists.Remove(list);
            _context.SaveChanges();
            return true;
        }

        public ShoppingListDTO GetShoppingList(int listId)
        {
            var currentUser = _accountService.GetCurrentUser().Result;
            if (currentUser == null)
            {
                return null;
            }

            var list = _context.ShoppingLists.Where(l => l.Id.Equals(listId) && l.Creator.Id.Equals(currentUser.Id)).Include(l => l.ShoppingListItems).ThenInclude(li => li.Item).FirstOrDefault();
            if (list == null)
            {
                return null;
            }

            return _mapper.Map<ShoppingListDTO>(list);
        }
        public List<ShoppingListDTO> GetShoppingLists()
        {
            var currentUser = _accountService.GetCurrentUser().Result;
            if (currentUser == null)
            {
                return null;
            }

            var lists = _context.ShoppingLists.Where(l => l.Creator.Id.Equals(currentUser.Id)).ToList();
            if (lists == null)
            {
                return null;
            }

            return _mapper.Map<List<ShoppingListDTO>>(lists);
        }


        public bool DeleteShoppingListItem(int itemId)
        {
            var creator = _accountService.GetCurrentUser().Result;
            var listItem = _context.ShoppingListItems.FirstOrDefault(li => li.Id.Equals(itemId));
            if (listItem == null)
            {
                return false;
            }
            var listContaining = _context.ShoppingLists.Where(l => l.ShoppingListItems.Contains(listItem) && l.Creator.Id.Equals(creator.Id)).FirstOrDefault();
            if (listContaining == null)
            {
                return false;
            }
            _context.ShoppingListItems.Remove(listItem);
            _context.SaveChanges();
            return true;
        }

        public ShoppingListItemDTO AddShoppingListItem(ShoppingListItemDTO listItem, int listId)
        {
            var creator = _accountService.GetCurrentUser().Result;
            var shoppingListFromDb = _context.ShoppingLists
                .Where(l => l.Id.Equals(listId) && l.Creator.Id.Equals(creator.Id))
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
            var creator = _accountService.GetCurrentUser().Result;
            var shoppingListFromDb = _context.ShoppingLists
                .Where(l => l.Id.Equals(listId) && l.Creator.Id.Equals(creator.Id))
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

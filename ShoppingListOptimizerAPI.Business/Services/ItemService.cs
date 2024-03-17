using AutoMapper;
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

        public List<ItemQueryResultDTO> GetItems(double? distance, string? barcode, string? name, double? priceMin, double? priceMax, double[] shopIds)
        {
            double[] userLocation = _accountService.GetCurrentLocation().Result;

            var query = _context.ItemPriceEntries
            .Where(itemPriceEntry =>
                (name == null || itemPriceEntry.Item.Name.Contains(name)) &&
                (barcode == null || itemPriceEntry.Item.Barcode.Equals(barcode)) &&
                (priceMin == null || itemPriceEntry.Price >= priceMin) &&
                (priceMax == null || itemPriceEntry.Price <= priceMax) &&
                (shopIds.Length == 0 || shopIds.Contains(itemPriceEntry.Shop.Id)))
            .Where(itemPriceEntry => (
                !_context.ItemPriceEntries.Any(other => (
                    (other.Shop.Id == itemPriceEntry.Shop.Id) &&
                    (other.CreatedAt > itemPriceEntry.CreatedAt)))))
            .Include(itemPirceEntry => itemPirceEntry.Shop)
                .ThenInclude(shop => shop.Location)
            .Include(itemPirceEntry => itemPirceEntry.Shop)
                .ThenInclude(shop => shop.Creator)
            .Include(itemPirceEntry => itemPirceEntry.Shop)
                .ThenInclude(shop => shop.Company)
            .Include(itemPriceEntry => itemPriceEntry.Item)
            .ToList();

            var dist = query.Where(itemPriceEntry => (distance == null || distance >= GeoFunctions.CalculateDistance(itemPriceEntry.Shop.Location.Latitude, itemPriceEntry.Shop.Location.Longitude, userLocation[0], userLocation[1]))).ToList();

            var result = dist.Select(itemPriceEntry => new ItemQueryResultDTO
            {
                Price = itemPriceEntry.Price,
                CreatedAt = itemPriceEntry.CreatedAt,
                Item = _mapper.Map<ItemDTO>(itemPriceEntry.Item),
                Shop = _mapper.Map<ShopDTO>(itemPriceEntry.Shop),
                Distance = GeoFunctions.CalculateDistance(itemPriceEntry.Shop.Location.Latitude,
                                                        itemPriceEntry.Shop.Location.Longitude,
                                                        userLocation[0],
                                                        userLocation[1])
            })
            .OrderBy(dto => dto.Distance)
            .ToList();





            return result;
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
            //look up item if exists
            var exists = _context.Items.Where(i => i.Barcode.Equals(item.Barcode)).FirstOrDefault();
            if (exists != null)
            {
                return null;
            }
            //link creator to item
            var _item = _mapper.Map<Item>(item);
            if (creator == null)
            {
                return null;
            }
            _item.Creator = creator;
            _context.Items.Add(_item);
            _context.SaveChanges();
            return _mapper.Map<ItemDTO>(_item);
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

        public double GetMaxItemPrice()
        {
            var max = _context.ItemPriceEntries.Max(entry => entry.Price);
            return max;
        }


        public List<ItemChartDTO> GetChartItemPriceForShops(string barcode, int[] shopIds)
        {
            var query = _context.ItemPriceEntries
                .Where(entry => entry.Item.Barcode == barcode)
                .Include(entry => entry.Shop)
                .Include(entry => entry.Item);

            List<ItemChartDTO> itemPriceCharts = new List<ItemChartDTO>();
            if (shopIds.Length == 0)
            {
                var filtered = (from entry in query
                                where entry.Item.Barcode == barcode
                                group entry by new { Date = entry.CreatedAt.Date, entry.Shop.Id } into grp
                                select grp.OrderBy(entry => entry.CreatedAt).FirstOrDefault())
                        .AsQueryable().ToList();

                var groupedByDay = filtered.GroupBy(entry => entry.CreatedAt.Date);
                var result = groupedByDay.ToList();



                List<ItemChartSeriesDTO> itemChartSeries = new List<ItemChartSeriesDTO>();

                foreach (var group in result)
                {
                    var itemChartSeriesElement = new ItemChartSeriesDTO
                    {
                        Name = group.Key.Date,
                        Value = group.Average(entry => entry.Price)
                    };

                    itemChartSeries.Add(itemChartSeriesElement);
                }


                var itemPriceChart = new ItemChartDTO
                {
                    Name = "Average price of " + filtered.First().Item.Name,
                    Series = itemChartSeries
                };

                itemPriceCharts.Add(itemPriceChart);
                return itemPriceCharts;


            }
            else
            {
                foreach (int shopId in shopIds)
                {
                    // Filter by shop IDs and keeping only the latest in one day
                    var filtered = query
                            .Where(entry => entry.Shop.Id.Equals(shopId))
                            .Include(entry => entry.Shop)
                            .Include(entry => entry.Item)
                            .OrderByDescending(entry => entry.CreatedAt)
                            .GroupBy(entry => entry.CreatedAt.Date)
                            .Select(group => group.OrderByDescending(entry => entry.CreatedAt).First());


                    var result = filtered.ToList();
                    if (result.Count > 0)
                    {
                        ItemChartDTO itemPriceChart = new ItemChartDTO();
                        itemPriceChart.Name = result.First().Item.Name + " at " + result.First().Shop.Name;

                        List<ItemChartSeriesDTO> itemChartSeries = new List<ItemChartSeriesDTO>();
                        foreach (var item in result)
                        {
                            ItemChartSeriesDTO itemChartSeriesElement = new ItemChartSeriesDTO();
                            itemChartSeriesElement.Name = item.CreatedAt.Date;
                            itemChartSeriesElement.Value = item.Price;
                            itemChartSeries.Add(itemChartSeriesElement);
                        }
                        itemPriceChart.Series = itemChartSeries;
                        itemPriceCharts.Add(itemPriceChart);
                    }
                }
                return itemPriceCharts;
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

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingListOptimizerAPI.Business.DTOs;
using ShoppingListOptimizerAPI.Business.Services;
using ShoppingListOptimizerAPI.Data.Models;
using ShoppingListOptimizerAPI.Models.Requests;
using ShoppingListOptimizerAPI.Models.Responses;

namespace ShoppingListOptimizerAPI.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;
        private readonly IMapper _mapper;

        public ItemsController(ItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("{barcode}")]
        public ActionResult<ItemResponse> GetItemByBarcode(string barcode)
        {
            var item = _itemService.GetByBarcode(barcode);
            /*if (item == null)
            {
                item = new ItemDTO();
                item.Barcode = barcode;
                _itemService.Create(item);
            }*/
            return Ok(_mapper.Map<ItemResponse>(item));
        }

        [HttpGet]
        public ActionResult<List<ItemQueryResponse>> GetItems([FromQuery] double? distance, [FromQuery] string? barcode, [FromQuery] string? name, [FromQuery] double? priceMin, [FromQuery] double? priceMax, [FromQuery] double[]? shopIds)
        {
            var items = _itemService.GetItems(distance, barcode, name, priceMin, priceMax, shopIds);

            if (items != null)
            {
                return Ok(_mapper.Map<List<ItemQueryResponse>>(items));
            }
            return Ok();
        }

        
        [HttpGet("maxPrice")]
        public ActionResult<double> GetMaxItemPrice()
        {
            double price = _itemService.GetMaxItemPrice();
            return Ok(price);
        }

        
        [HttpGet("{barcode}/chart")]
        public ActionResult<List<ItemChartResponse>> GetChartItemPriceForShops(string barcode, [FromQuery] int[]? shopIds)
        {
            var itemPricesForShops = _itemService.GetChartItemPriceForShops(barcode, shopIds);

            if (itemPricesForShops != null)
            {
                return Ok(_mapper.Map<List<ItemChartResponse>>(itemPricesForShops));
            }
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Item> AddItem([FromBody] ItemRequest item)
        {
            var createdItem = _itemService.Create(_mapper.Map<ItemDTO>(item));
            //ItemDTO createdItem = null;
            if (createdItem == null)
            {
                return NotFound("Item creation failed");
            }
            return Ok(createdItem);
        }

        [Authorize]
        [HttpPost("{barcode}")]
        public ActionResult<Item> AddItemPrice(string barcode, [FromBody] ItemPriceRequest itemPriceEntryRequest)
        {
            var createdItemPrice = _itemService.CreateItemPriceEntry(barcode, itemPriceEntryRequest.ShopId, itemPriceEntryRequest.Price);

            if (createdItemPrice == null || itemPriceEntryRequest.Price <= 0)
            {
                return NotFound("Item price entry creation failed");
            }
            return Ok(createdItemPrice);
        }

    }
}

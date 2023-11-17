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

        [HttpGet("{barcode}")]
        public ActionResult<List<ItemResponse>> GetItemByBarcode(string barcode)
        {
            var item = _itemService.GetById(barcode);
            if (item == null)
            {
                item = new ItemDTO();
                item.Barcode = barcode;
                _itemService.Create(item);
            }
            return Ok(_mapper.Map<ItemResponse>(item));
        }

        [HttpGet("{id}")]
        public ActionResult<ItemResponse> GetItemById(string id)
        {
            var item = _itemService.GetById(id);
            if(item == null)
            {
                return NotFound("Item not found");
            }
            return Ok(_mapper.Map<ItemResponse>(item));
        }

        [HttpPost]
        public ActionResult<Item> AddItemEntry([FromBody] ItemRequest item)
        {
            var createdItem = _itemService.Create(_mapper.Map<ItemDTO>(item));
            if (createdItem == null)
            {
                return NotFound("Item creation failed");
            }
            return Ok(createdItem);
        }


    }
}

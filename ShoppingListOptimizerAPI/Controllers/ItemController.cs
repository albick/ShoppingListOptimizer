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

        [HttpGet]
        public ActionResult<List<ItemResponse>> Get()
        {
            var items = _itemService.GetAll();
            return Ok(_mapper.Map<List<ItemResponse>>(items));
        }

        [HttpGet("{id}")]
        public ActionResult<ItemResponse> GetById(string barcode)
        {
            var item = _itemService.GetById(barcode);
            if (item == null)
                return NotFound();

            return Ok(_mapper.Map<ItemResponse>(item));
        }

        [HttpPost]
        public ActionResult<Item> Create([FromBody] ItemRequest item)
        {
            var createdItem = _itemService.Create(_mapper.Map<ItemDTO>(item));
            return CreatedAtAction(nameof(GetById), new { barcode = createdItem.Barcode }, createdItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string barcode, [FromBody] ItemRequest item)
        {
            var updated = _itemService.Update(barcode, _mapper.Map<ItemDTO>(item));
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string barcode)
        {
            var deleted = _itemService.Delete(barcode);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        /*
        [Authorize(Roles = "User")]
        [HttpGet("user")]
        public IActionResult TestUser()
        {
            return Ok("user");
        }

        [Authorize(Roles = "Shop")]
        [HttpGet("shop")]
        public IActionResult TestShop()
        {
            return Ok("shop");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult TestAdmin()
        {
            return Ok("admin");
        }*/

    }
}

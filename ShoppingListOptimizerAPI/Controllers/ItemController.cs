using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingListOptimizerAPI.Business.Services;
using ShoppingListOptimizerAPI.Data.Models;

namespace ShoppingListOptimizerAPI.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemsController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public ActionResult<List<Item>> Get()
        {
            var items = _itemService.GetAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetById(string barcode)
        {
            var item = _itemService.GetById(barcode);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public ActionResult<Item> Create([FromBody] Item item)
        {
            var createdItem = _itemService.Create(item);
            return CreatedAtAction(nameof(GetById), new { barcode = createdItem.Barcode }, createdItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string barcode, [FromBody] Item item)
        {
            var updated = _itemService.Update(barcode, item);
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
        }

    }
}

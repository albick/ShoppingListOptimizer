using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingListOptimizerAPI.Business.DTOs;
using ShoppingListOptimizerAPI.Business.Services;
using ShoppingListOptimizerAPI.Models.Requests;
using ShoppingListOptimizerAPI.Models.Responses;

namespace ShoppingListOptimizerAPI.Controllers
{
    [Route("api/shoppinglists")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ShoppingListService _shoppingListService;

        public ShoppingListController(ShoppingListService shoppingListService, IMapper mapper)
        {
            _mapper = mapper;
            _shoppingListService = shoppingListService;
        }

        [HttpPost]
        public ActionResult<ShoppingListResponse> AddShoppingList([FromBody] ShoppingListRequest shoppingListRequest)
        {
            var shoppingList = _shoppingListService.AddShoppingList(_mapper.Map<ShoppingListDTO>(shoppingListRequest));
            if (shoppingList == null)
            {
                return NotFound("Shopping list creation failed");
            }
            return Ok(_mapper.Map<ShoppingListResponse>(shoppingList));
        }

        [HttpPut("{id}")]
        public ActionResult<ShoppingListResponse> UpdateShoppingList([FromBody] ShoppingListRequest shoppingListRequest, int id)
        {
            var shoppingList = _shoppingListService.UpdateShoppingList(_mapper.Map<ShoppingListDTO>(shoppingListRequest), id);
            if (shoppingList == null)
            {
                return NotFound("Shopping list updating failed");
            }
            return Ok(_mapper.Map<ShoppingListResponse>(shoppingList));
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteShoppingList(int id)
        {
            var success = _shoppingListService.DeleteShoppingList(id);
            if (success == false)
            {
                return NotFound("Shopping list deleting failed");
            }
            return Ok(true);
        }

        [HttpGet]
        public ActionResult<List<ShoppingListResponse>> GetShoppingLists()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<ShoppingListResponse> GetShoppingList(int id)
        {
            return Ok();
        }

        [HttpDelete("{listId}/items/{itemId}")]
        public IActionResult DeleteShoppingListItem(int listId, int itemId)
        {
            return Ok();
        }

        [HttpPost("{listId}/items")]
        public ActionResult<ShoppingListItemResponse> AddShoppingListItem([FromBody] ShoppingListItemRequest shoppingListItemRequest, int listId)
        {
            var shoppingListItem = _shoppingListService.AddShoppingListItem(_mapper.Map<ShoppingListItemDTO>(shoppingListItemRequest), listId);
            if (shoppingListItem == null)
            {
                return NotFound("Shopping list item adding failed");
            }
            return Ok(_mapper.Map<ShoppingListItemResponse>(shoppingListItem));
        }

        [HttpPut("{listId}/items/{itemId}")]
        public ActionResult<ShoppingListItemResponse> UpdateShoppingListItem([FromBody] ShoppingListItemRequest shoppingListItemRequest, int listId, int itemId)
        {
            var shoppingListItem = _shoppingListService.UpdateShoppingListItem(_mapper.Map<ShoppingListItemDTO>(shoppingListItemRequest), itemId, listId);
            if (shoppingListItem == null)
            {
                return NotFound("Shopping list item updating failed");
            }
            return Ok(_mapper.Map<ShoppingListItemResponse>(shoppingListItem));
        }
    }
}

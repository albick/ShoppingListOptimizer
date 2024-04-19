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
    [Authorize]
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

        [HttpGet]
        public ActionResult<List<ShoppingListResponse>> GetShoppingLists()
        {
            var shoppingLists = _shoppingListService.GetShoppingLists();
            if (shoppingLists == null)
            {
                return NotFound("No shopping lists found");
            }
            return Ok(_mapper.Map<List<ShoppingListResponse>>(shoppingLists));
        }

        [HttpGet("{id}")]
        public ActionResult<ShoppingListResponse> GetShoppingList(int id)
        {
            var shoppingList = _shoppingListService.GetShoppingList(id);
            if (shoppingList == null)
            {
                return NotFound("No shopping list found");
            }
            return Ok(_mapper.Map<ShoppingListResponse>(shoppingList));
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

        [HttpDelete("{listId}/items/{itemId}")]
        public ActionResult<bool> DeleteShoppingListItem(int itemId)
        {
            var success = _shoppingListService.DeleteShoppingListItem(itemId);
            if (success == false)
            {
                return NotFound("Shopping list item deleting failed");
            }
            return Ok(true);
        }


        [HttpGet("{id}/optimize")]
        public ActionResult<List<ShopOptimizationResponse>> OptimizeShoppingList(int id, [FromQuery] double distance, int selectedMode,bool openNow)
        {
            var optimizationResult = _shoppingListService.OptimizeShoppingList(id, distance, selectedMode,openNow);
            if (optimizationResult != null)
            {
                return Ok(_mapper.Map < List<ShopOptimizationResponse>>(optimizationResult));
            }
            return NotFound("Shopping list cannot be optimized, because no shop fulfills the query criteria");
        }
    }
}

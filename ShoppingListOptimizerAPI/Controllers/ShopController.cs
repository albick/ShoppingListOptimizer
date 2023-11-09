using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingListOptimizerAPI.Business.DTOs;
using ShoppingListOptimizerAPI.Business.Services;
using ShoppingListOptimizerAPI.Data.Models;
using ShoppingListOptimizerAPI.Models.Requests;
using ShoppingListOptimizerAPI.Models.Responses;
using System.Collections.Generic;

namespace ShoppingListOptimizerAPI.Controllers
{
    [Route("api/shops")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ShopService _shopService;
        private readonly IMapper _mapper;

        public ShopController(ShopService shopService, IMapper mapper)
        {
            _shopService = shopService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<ShopResponse>> GetShops([FromQuery] double? distance)
        {
            List<ShopDTO>? shops;
            if (distance == null)
            {
                shops = _shopService.GetShops(null);
            }
            else
            {
                shops = _shopService.GetShops(distance);
            }

            if (shops != null) {
                return Ok(_mapper.Map<List<ShopResponse>>(shops));
            }
            return Ok();
        }

        
        [HttpGet("{id}")]
        public ActionResult<ShopResponse> GetShopById(int id)
        {
            return Ok(_mapper.Map<ShopResponse>(_shopService.GetShopById(id)));
        }

        [HttpPost]
        public ActionResult<ShopResponse> AddShopCommunity([FromBody] ShopRequest shop)
        {
            var createdShop = _shopService.AddShopCommunity(_mapper.Map<ShopDTO>(shop));
            return CreatedAtAction(nameof(GetShopById), new { id = createdShop.Id }, createdShop);

        }


    }
}

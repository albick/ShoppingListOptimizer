using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        private readonly AccountService _accountService;
        private readonly IMapper _mapper;

        public ShopController(ShopService shopService, AccountService accountService, IMapper mapper)
        {
            _shopService = shopService;
            _accountService = accountService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<List<ShopResponse>> GetShops([FromQuery] double? distance, [FromQuery] string? name)
        {
            List<ShopDTO>? shops;
            if (distance == null)
            {
                shops = _shopService.GetShops(0, name);
            }
            else
            {
                shops = _shopService.GetShops((double)distance,name);
            }


            if (shops != null)
            {
                return Ok(_mapper.Map<List<ShopResponse>>(shops));
            }
            return Ok();
        }


        [HttpGet("{id}")]
        public ActionResult<ShopResponse> GetShopById(int id)
        {
            return Ok(_mapper.Map<ShopResponse>(_shopService.GetShopById(id)));
        }

        [HttpGet("maxDistance")]
        public ActionResult<double> GetMaxShopDistance()
        {
            double distance = _shopService.GetMaxShopDistance();
            return Ok(distance);
        }

        [Authorize]
        [HttpPost]
        public ActionResult<ShopResponse> AddShopCommunity([FromBody] ShopRequest shop)
        {
            var createdShop = _shopService.AddShopCommunity(_mapper.Map<ShopDTO>(shop));
            return CreatedAtAction(nameof(GetShopById), new { id = createdShop.Id }, createdShop);

        }

        [HttpGet("companies")]
        public ActionResult<List<string>> GetCompanies()
        {
            var companies = _accountService.GetCompanies();
            return Ok(companies);
        }


    }
}

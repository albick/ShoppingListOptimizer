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
    public class ShopsController : ControllerBase
    {
        private readonly ShopService _shopService;
        private readonly AccountService _accountService;
        private readonly IMapper _mapper;

        public ShopsController(ShopService shopService, AccountService accountService, IMapper mapper)
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

        [Authorize(Roles = "Shop")]
        [HttpPut("{id}")]
        public ActionResult<ShopResponse> UpdateShopById([FromBody] ShopRequest shop,int id)
        {
            var result = _shopService.UpdateShopById(_mapper.Map<ShopDTO>(shop), id);
            if(result!=null)
            {
                return Ok(_mapper.Map<ShopResponse>(result));
            }    
            return NotFound("Shop update failed");
        }

        [Authorize(Roles = "Shop")]
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteShop(int id)
        {
            var result=_shopService.DeleteShopById(id);
            if (result == true)
            {
                return Ok(result);
            }
            return NotFound("Shop deletion failed");
        }



        [HttpGet("maxDistance")]
        public ActionResult<double> GetMaxShopDistance()
        {
            double distance = _shopService.GetMaxShopDistance();
            return Ok(distance);
        }

        [Authorize]
        [HttpPost]
        public ActionResult<ShopResponse> AddShop([FromBody] ShopRequest shop)
        {
            var createdShop = _shopService.AddShop(_mapper.Map<ShopDTO>(shop));
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

using AutoMapper;
using ShoppingListOptimizerAPI.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingListOptimizerAPI.Data.Models;

namespace ShoppingListOptimizerAPI.Business.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemDTO>().ForMember(dest=>dest.Name,opt=>opt.MapFrom(src=>src.Name+"_XYZ"));
            
            // Other mappings...
        }
    }
}

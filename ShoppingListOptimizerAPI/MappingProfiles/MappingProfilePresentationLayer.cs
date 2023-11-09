using AutoMapper;
using ShoppingListOptimizerAPI.Business.DTOs;
using ShoppingListOptimizerAPI.Data.Models;
using ShoppingListOptimizerAPI.Models;
using ShoppingListOptimizerAPI.Models.Requests;
using ShoppingListOptimizerAPI.Models.Responses;

namespace ShoppingListOptimizerAPI.MappingProfiles
{
    public class MappingProfilePresentationLayer : Profile
    {
        public MappingProfilePresentationLayer()
        {
            CreateMap<ItemResponse, ItemDTO>();
            CreateMap<ItemRequest, ItemDTO>();
            CreateMap<ShopResponse, ShopDTO>();
            // Other mappings...
            CreateMap<LocationModel, LocationDTO>()
           .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<AccountModel, AccountDTO>();
            CreateMap<AccountDTO, AccountModel>();

            CreateMap<LocationDTO, LocationModel>();
            CreateMap<ShopDTO, ShopResponse>()
            .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator));

            CreateMap<ShopRequest, ShopDTO>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details))
           .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
           .ForMember(dest => dest.OpeningHours, opt => opt.MapFrom(src => src.OpeningHours))
           .ForMember(dest => dest.Creator, opt => opt.Ignore())  // Ignore Creator property
           .ForMember(dest => dest.Id, opt => opt.Ignore())       // Ignore Id property
           .ForMember(dest => dest.Company, opt => opt.MapFrom(src => new AccountDTO { Id = src.CompanyId }));


        }
    }
}

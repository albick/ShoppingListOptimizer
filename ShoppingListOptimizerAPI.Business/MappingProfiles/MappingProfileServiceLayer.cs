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
    public class MappingProfileServiceLayer : Profile
    {
        public MappingProfileServiceLayer()
        {
            CreateMap<Item, ItemDTO>();
            CreateMap<ItemDTO, Item>();


            // Mapping from Shop to ShopDTO
            CreateMap<Shop, ShopDTO>()
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
            .ForMember(dest => dest.OpeningHours, opt => opt.MapFrom(src => src.OpeningHours))
            .ForMember(dest => dest.DistanceFromUser, opt => opt.MapFrom(src => 0));

            CreateMap<ShopDTO, Shop>()
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
            .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator))
            .ForMember(dest => dest.OpeningHours, opt => opt.MapFrom(src => src.OpeningHours))
            .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company));

            CreateMap<OpeningHoursDTO, OpeningHours>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<OpeningHours, OpeningHoursDTO>();

            CreateMap<Location, LocationDTO>();



            CreateMap<LocationDTO, Location>();
            // Other mappings...

            CreateMap<Account, AccountDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));

            CreateMap<AccountDTO, Account>()
            .ForMember(dest => dest.NormalizedUserName, opt => opt.Ignore())
            .ForMember(dest => dest.Email, opt => opt.Ignore())
            .ForMember(dest => dest.NormalizedEmail, opt => opt.Ignore())
            .ForMember(dest => dest.EmailConfirmed, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore())
            .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
            .ForMember(dest => dest.PhoneNumber, opt => opt.Ignore())
            .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.Ignore())
            .ForMember(dest => dest.TwoFactorEnabled, opt => opt.Ignore())
            .ForMember(dest => dest.LockoutEnd, opt => opt.Ignore())
            .ForMember(dest => dest.LockoutEnabled, opt => opt.Ignore())
            .ForMember(dest => dest.AccessFailedCount, opt => opt.Ignore());

            CreateMap<ItemPriceEntry, ItemPriceEntryDTO>();
            CreateMap<ItemPriceEntryDTO, ItemPriceEntry>();
        }
    }
}

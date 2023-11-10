using AutoMapper;
using ShoppingListOptimizerAPI.Business.DTOs;
using ShoppingListOptimizerAPI.Data.Models;
using ShoppingListOptimizerAPI.Models;
using ShoppingListOptimizerAPI.Models.Requests;
using ShoppingListOptimizerAPI.Models.Responses;
using System;

namespace ShoppingListOptimizerAPI.MappingProfiles
{
    public class MappingProfilePresentationLayer : Profile
    {
        public MappingProfilePresentationLayer()
        {
            CreateMap<ItemResponse, ItemDTO>();
            CreateMap<ItemRequest, ItemDTO>();
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
           .ForMember(dest => dest.Company, opt => opt.MapFrom(src => new AccountDTO { UserName = src.CompanyName }));

            //CreateMap<ShopResponse, ShopDTO>();

            CreateMap<string, TimeSpan>().ConvertUsing(new StringToTimeSpanConverter());
            CreateMap<OpeningHoursModel, OpeningHoursDTO>()
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime));

            CreateMap<TimeSpan, string>().ConvertUsing(new TimeSpanToStringConverter());

            CreateMap<OpeningHoursDTO, OpeningHoursModel>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime));

        }
    }

    public class StringToTimeSpanConverter : ITypeConverter<string, TimeSpan>
    {
        public TimeSpan Convert(string source, TimeSpan destination, ResolutionContext context)
        {
            if (TimeSpan.TryParseExact(source, "h\\:m\\:s", null, out TimeSpan result))
            {
                return result;
            }
            else
            {
                // Handle the parsing error, for now, return TimeSpan.Zero
                return TimeSpan.Zero;
            }
        }
    }

    public class TimeSpanToStringConverter : ITypeConverter<TimeSpan, string>
    {
        public string Convert(TimeSpan source, string destination, ResolutionContext context)
        {
            return source.ToString("h\\:m\\:s");
        }
    }
}

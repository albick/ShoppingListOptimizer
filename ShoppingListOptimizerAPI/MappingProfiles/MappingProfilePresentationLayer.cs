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
            CreateMap<ItemDTO, ItemResponse>();
            CreateMap<ItemRequest, ItemDTO>()
            .ForMember(dest => dest.Creator, opt => opt.Ignore());
            // Other mappings...
            CreateMap<LocationModel, LocationDTO>()
           .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<AccountModel, AccountDTO>();
            CreateMap<AccountDTO, AccountModel>();

            CreateMap<LocationDTO, LocationModel>();


            CreateMap<ItemChartDTO, ItemChartResponse>()
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.series, opt => opt.MapFrom(src => src.Series));

            CreateMap<ItemChartSeriesDTO, ItemChartSeries>()
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.value, opt => opt.MapFrom(src => src.Value));


            CreateMap<ShopDTO, ShopResponse>()
            .ForMember(dest => dest.creator, opt => opt.MapFrom(src => src.Creator))
            .ForMember(dest => dest.distanceFromUser, opt => opt.MapFrom(src => src.DistanceFromUser));


            CreateMap<ShopRequest, ShopDTO>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details))
           .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
           .ForMember(dest => dest.OpeningHours, opt => opt.MapFrom(src => src.OpeningHours))
           .ForMember(dest => dest.Creator, opt => opt.Ignore())  // Ignore Creator property
           .ForMember(dest => dest.Id, opt => opt.Ignore())       // Ignore Id property
           .ForMember(dest => dest.DistanceFromUser, opt => opt.Ignore())
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

            CreateMap<ItemQueryResultDTO, ItemQueryResponse>()
                .ForMember(dest => dest.price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.createdAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.itemBarcode, opt => opt.MapFrom(src => src.Item.Barcode))
                .ForMember(dest => dest.itemName, opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(dest => dest.itemUnit, opt => opt.MapFrom(src => src.Item.Unit))
                .ForMember(dest => dest.itemQuantity, opt => opt.MapFrom(src => src.Item.Quantity))
                .ForMember(dest => dest.shopName, opt => opt.MapFrom(src => src.Shop.Name))
                .ForMember(dest => dest.shopId, opt => opt.MapFrom(src => src.Shop.Id))
                .ForMember(dest => dest.distance, opt => opt.MapFrom(src => src.Distance))
                ;

            CreateMap<ShoppingListRequest, ShoppingListDTO>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DateModified, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details))
                .ForMember(dest => dest.Creator, opt => opt.Ignore())
                .ForMember(dest => dest.ShoppingListItems, opt => opt.Ignore())
                ;

            CreateMap<ShoppingListDTO, ShoppingListResponse>()
                .ForMember(dest=>dest.id,opt=>opt.MapFrom(src=>src.Id))
                .ForMember(dest=>dest.name,opt=>opt.MapFrom(src=>src.Name))
                .ForMember(dest=>dest.dateModified,opt=>opt.MapFrom(src=>src.DateModified))
                .ForMember(dest=>dest.details,opt=>opt.MapFrom(src=>src.Details))
                .ForMember(dest=>dest.creator,opt=>opt.MapFrom(src=>src.Creator))
                .ForMember(dest=>dest.shoppingListItems,opt=>opt.MapFrom(src=>src.ShoppingListItems))
                ;

            CreateMap<ShoppingListItemDTO, ShoppingListItemResponse>()
                .ForMember(dest=>dest.id,opt=>opt.MapFrom(src=>src.Id))
                .ForMember(dest=>dest.count,opt=>opt.MapFrom(src=>src.Count))
                .ForMember(dest=>dest.itemId,opt=>opt.MapFrom(src=>src.Item.Barcode))
                ;

            CreateMap<ShoppingListItemRequest, ShoppingListItemDTO>()
                .ForMember(dest=>dest.Id,opt=>opt.Ignore())
                .ForMember(dest=>dest.Count,opt=>opt.MapFrom(src=>src.Count))
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => new ItemDTO { Barcode = src.ItemId}));
            ;
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

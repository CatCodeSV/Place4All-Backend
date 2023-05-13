using System.Linq;
using AutoMapper;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Mapping;

public class RestaurantMapper : Profile
{
    public RestaurantMapper()
    {
        CreateMap<Restaurant, RestaurantDto>();
        CreateMap<RestaurantDto, Restaurant>();
        CreateMap<Restaurant, RestaurantSummarizedDto>()
            .ForMember(x => x.Image, opt => opt.MapFrom(src => src.Images.FirstOrDefault().Link))
            .ForMember(x => x.NumberOfReviews, opt => opt.MapFrom(src => src.Reviews.Count))
            .ForMember(x => x.Rating,
                opt => opt.MapFrom(src =>
                    src.Reviews.Average(r => r.Value)))
            .ForMember(x => x.Address,
                opt => opt.MapFrom(src =>
                    src.Address.Street + ", " + src.Address.Number + ", " + src.Address.City + ", " +
                    src.Address.ZipCode))
            .ForMember(x => x.Summary, opt => opt.MapFrom(src => src.Description.Substring(0, 100) + "..."));
        CreateMap<RestaurantSummarizedDto, Restaurant>();
    }
}
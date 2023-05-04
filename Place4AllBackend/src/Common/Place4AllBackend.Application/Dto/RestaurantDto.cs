using System.Collections.Generic;
using System.Linq;
using Mapster;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Dto;

public class RestaurantDto : IRegister
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AddressId { get; set; }
    public AddressDto Address { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public double Rating { get; set; } = 0;
    public int NumberOfReviews { get; set; } = 0;
    public List<ImageDto> Images { get; set; }
    public List<FeatureDto> Features { get; set; }
    public List<ReviewDto> Reviews { get; set; }
    
    public string CreateDate { get; set; }

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Restaurant, RestaurantDto>()
            .Map(dest => dest.CreateDate,
                src => $"" + $"{src.CreateDate.ToShortDateString()}");
    }
}
using System.Collections.Generic;
using Mapster;
using Place4AllBackendAyti.Domain.Entities;

namespace Place4AllBackend.Application.Dto;

public class RestaurantDto : IRegister
{
    public RestaurantDto()
    {
        Features = new List<FeatureDto>();
        Images = new List<string>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public int AddressId { get; set; }
    public string Descripcion { get; set; }
    public string PhoneNumber { get; set; }
    public IList<string> Images { get; set; }
    public IList<FeatureDto> Features { get; set; }
    public string CreateDate { get; set; }
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Restaurant, RestaurantDto>()
            .Map(dest => dest.CreateDate,
                src => $"" + $"{src.CreateDate.ToShortDateString()}");
    }
}
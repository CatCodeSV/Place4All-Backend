using Mapster;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Dto;

public class AddressDto : IRegister
{
    public int Id { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; } 
    public string Province { get; set; }
    public string CreateDate { get; set; }
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<City, CityDto>()
            .Map(dest => dest.CreateDate,
                src => $"{src.CreateDate.ToShortDateString()}");
    }
}
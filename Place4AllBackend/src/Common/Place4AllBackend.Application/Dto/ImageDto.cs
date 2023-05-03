using Mapster;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Dto;

public class ImageDto : IRegister
{
    public int Id { get; set; }
    public string Link { get; set; }
    public int RestaurantId { get; set; }
    public string CreateDate { get; set; }

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Image, ImageDto>()
            .Map(dest => dest.CreateDate,
                src => $"" + $"{src.CreateDate.ToShortDateString()}");
    }
}
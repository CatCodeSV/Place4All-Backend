using System.Collections.Generic;
using Mapster;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Dto;

public class ReviewDto : IRegister
{
    public int Id { get; set; }
    public float Value { get; set; }
    public string Comment { get; set; }
    public InformationAccuracy InformationAccuracy { get; set; }
    public int RestaurantId { get; set; }
    public List<Feature> AdditionalFeatures { get; set; }

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Restaurant, RestaurantDto>()
            .Map(dest => dest.CreateDate,
                src => $"" + $"{src.CreateDate.ToShortDateString()}");
    }
}
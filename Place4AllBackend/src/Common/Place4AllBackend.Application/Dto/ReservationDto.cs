using System;
using System.Collections.Generic;

namespace Place4AllBackend.Application.Dto;

public class ReservationDto
{
    public ReservationDto()
    {
        Features = new List<FeatureDto>();
    }
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public int People { get; set; }
    public IList<FeatureDto> Features { get; set; }
    public string SpecialInstructions { get; set; }
    public DateTime Date { get; set; }
}
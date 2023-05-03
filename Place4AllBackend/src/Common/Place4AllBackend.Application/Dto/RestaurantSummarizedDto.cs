using System.Collections.Generic;
using System.Linq;
using Mapster;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Dto;

public class RestaurantSummarizedDto 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public string Image { get; set; }
}
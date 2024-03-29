using System;
using System.Collections.Generic;

namespace Place4AllBackend.Application.Dto;

public class RestaurantDto
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
    public string Creator { get; set; }
    public DateTime CreateDate { get; set; }
    public string Modifier { get; set; }
    public DateTime? ModifyDate { get; set; }
}
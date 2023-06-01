using System.Collections.Generic;
using Place4AllBackend.Domain.Entities;
using Place4AllBackend.Domain.Enums;

namespace Place4AllBackend.Application.Dto;

public class ReviewDto 
{
    public int Id { get; set; }
    public float Value { get; set; }
    public string Comment { get; set; }
    public InformationAccuracy InformationAccuracy { get; set; }
    public int RestaurantId { get; set; }
    public List<Feature> AdditionalFeatures { get; set; }
    public string UserName { get; set; }
    public string CreateDate { get; set; }
    public string Creator { get; set; }
    public string Title { get; set; }
}
using System.Collections.Generic;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;
using Place4AllBackend.Domain.Enums;

namespace Place4AllBackend.Application.Services.Reviews.Commands.Create;

public class CreateReviewCommand : IRequestWrapper<ReviewDto>
{
    public string Title { get; set; }
    public float Value { get; set; }
    public string Comment { get; set; }
    public InformationAccuracy InformationAccuracy { get; set; }
    public int RestaurantId { get; set; }
    public List<Feature> AdditionalFeatures { get; set; }
}
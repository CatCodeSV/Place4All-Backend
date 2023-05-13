using Place4AllBackend.Application.Dto;
using AutoMapper;

namespace Place4AllBackend.Application.Mapping;

public class FeatureMapper : Profile
{
    public FeatureMapper()
    {
        CreateMap<Domain.Entities.Feature, FeatureDto>();
        CreateMap<FeatureDto, Domain.Entities.Feature>();
    }
}
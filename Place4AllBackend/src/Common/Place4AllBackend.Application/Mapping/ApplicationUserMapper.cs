using AutoMapper;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Mapping;

public class ApplicationUserMapper : Profile
{
    public ApplicationUserMapper()
    {
        CreateMap<Domain.Entities.ApplicationUser, ApplicationUserDto>();
        CreateMap<ApplicationUserDto, Domain.Entities.ApplicationUser>();
    }
}
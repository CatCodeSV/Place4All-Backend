using System;
using AutoMapper;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Mapping;

public class ApplicationUserMapper : Profile
{
    public ApplicationUserMapper()
    {
        CreateMap<Domain.Entities.ApplicationUser, ApplicationUserDto>()
            .ForMember(x => x.Age,
                opt => opt.MapFrom(src => DateTime.Now.Year - src.BirthDate.Year));
        CreateMap<ApplicationUserDto, Domain.Entities.ApplicationUser>();
    }
}
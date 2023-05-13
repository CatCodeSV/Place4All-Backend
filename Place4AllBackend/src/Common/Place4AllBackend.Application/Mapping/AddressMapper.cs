using AutoMapper;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Mapping;

public class AddressMapper : Profile
{
    public AddressMapper()
    {
        CreateMap<Domain.Entities.Address, AddressDto>();
        CreateMap<AddressDto, Domain.Entities.Address>();
    }
}
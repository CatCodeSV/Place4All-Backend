using AutoMapper;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Mapping;

public class ReservationsMapper : Profile
{
    public ReservationsMapper()
    {
        CreateMap<Domain.Entities.Reservation, ReservationDto>();
        CreateMap<ReservationDto, Domain.Entities.Reservation>();
    }
}
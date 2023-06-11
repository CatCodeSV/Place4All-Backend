using AutoMapper;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Mapping;

public class ReservationsMapper : Profile
{
    public ReservationsMapper()
    {
        CreateMap<Domain.Entities.Reservation, ReservationDto>()
            .ForMember(x => x.RestaurantName, opt => opt.MapFrom(x => x.Restaurant.Name));
        CreateMap<ReservationDto, Domain.Entities.Reservation>();
    }
}
using System.Collections.Generic;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Reservations.Queries.GetReservationByUser;

public class GetReservationByUserQuery : IRequestWrapper<List<ReservationDto>>
{
}
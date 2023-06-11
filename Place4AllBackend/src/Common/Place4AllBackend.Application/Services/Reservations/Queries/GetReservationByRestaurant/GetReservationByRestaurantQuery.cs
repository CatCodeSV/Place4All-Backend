using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.Reservations.Queries.GetReservationByRestaurant
{
    public class GetReservationByRestaurantQuery : IRequestWrapper<List<ReservationDto>>
    {
        public int RestaurantId { get; set; }

    }
}

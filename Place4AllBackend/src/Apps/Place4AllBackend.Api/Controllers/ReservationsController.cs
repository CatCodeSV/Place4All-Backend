using Microsoft.AspNetCore.Mvc;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Common.Security;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Application.Reservations.Commands.Create;
using Place4AllBackend.Application.Reservations.Queries.GetReservationByRestaurant;
using Place4AllBackend.Application.Reservations.Queries.GetReservationByUser;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Place4AllBackend.Api.Controllers
{
    /// <sumary>
    /// Reservations
    /// </sumary>
    [Authorize]
    public class ReservationsController : BaseApiController
    {
        /// <sumary>
        /// Create a new Reservation
        /// </sumary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<ReservationDto>>> Create(CreateReservationCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Get Reviews by User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("User/{id}")]
        public async Task<ActionResult<ServiceResult<List<ReservationDto>>>> GetByUser(string id,
        CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetReservationByUserQuery() { ApplicationUserId = id }, cancellationToken));
        }

        /// <summary>
        /// Get Reviews by Restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("Restaurant/{id}")]
        public async Task<ActionResult<ServiceResult<List<ReservationDto>>>> GetByRestaurant(int id,
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetReservationByRestaurantQuery() { RestaurantId = id }, cancellationToken));
        }

    }
}

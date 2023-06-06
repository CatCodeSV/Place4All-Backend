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
using Place4AllBackend.Application.Reservations.Commands.Delete;
using Place4AllBackend.Application.Services.Reservations.Commands.Create;

namespace Place4AllBackend.Api.Controllers
{
    /// <sumary>
    /// Reservations
    /// </sumary>
    [Authorize (Roles = "User")]
    [Authorize (Roles = "Admin")]
    public class ReservationsController : BaseApiController
    {
        /// <sumary>
        /// Create a new Reservation
        /// </sumary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<ReservationDto>>> Create(CreateReservationCommand command,
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Get Reservations by User
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("User")]
        public async Task<ActionResult<ServiceResult<List<ReservationDto>>>> GetByUser(
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetReservationByUserQuery(), cancellationToken));
        }

        /// <summary>
        /// Get Reservations by Restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("Restaurant/{id:int}")]
        public async Task<ActionResult<ServiceResult<List<ReservationDto>>>> GetByRestaurant(int id,
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetReservationByRestaurantQuery() { RestaurantId = id },
                cancellationToken));
        }

        /// <summary>
        /// Delete reservation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResult<ReservationDto>>> Delete(int id,
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteReservationsCommand() { Id = id }, cancellationToken));
        }
    }
}

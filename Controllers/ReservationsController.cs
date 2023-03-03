using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers;
[ApiController, Route("Reservations")]
public class ReservationsController : Controller
{
    private readonly IReservationsService _reservationsService;

    public ReservationsController(IReservationsService reservationsService)
    {
        _reservationsService = reservationsService;
    }

    [HttpGet]
    public List<Reservations> Get() => _reservationsService.Get();

    [HttpGet("user/{usuarioId}")]
    public List<Reservations> GetUserReserva(string usuarioId) =>
         _reservationsService.GetUserReserva(usuarioId);

    [HttpGet("{id:length(24)}")]
    public async Task<Reservations> Get(string id) => await _reservationsService.Get(id);

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Reservations reservation)
    {
        await _reservationsService.Create(reservation);
        return CreatedAtAction(nameof(Get), new { id = reservation.Id }, reservation);
    }

    [HttpPut]
    public async Task<IActionResult> Put(string id, Reservations reservationInf)
    {
        var reserva = await _reservationsService.Get(id);

        if (reserva == null)
        {
            return NotFound();
        }

        reservationInf.Id = reserva.Id;
        await _reservationsService.Update(reserva);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Remove(Reservations reservation)
    {
        var reservaChecked = await _reservationsService.Get(reservation.Id.ToString());
        if (reservaChecked == null)
        {
            return NoContent();
        }
        
        _reservationsService.Remove(reservaChecked);

        return NoContent();
    }
}
using System;
using System.Collections.Generic;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Services.Reservations.Commands.Create;

public class CreateReservationCommand : IRequestWrapper<ReservationDto>
{
    public string SpecialInstructions { get; set; }
    public int People { get; set; }
    public DateTime Date { get; set; }
    public int RestaurantId { get; set; }
    public List<int> Features { get; set; } = new List<int>();
}
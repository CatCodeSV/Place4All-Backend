using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services;

public class ReservationsService: IReservationsService
{
    private readonly IMongoRepository<Reservations> _reservas;

    public ReservationsService(IMongoRepository<Reservations> settings)
    {
        _reservas = settings;
    }

    public List<Reservations> Get() => _reservas.AsQueryable().ToList();

    public List<Reservations> GetUserReserva(string usuarioId) =>
        _reservas.FilterBy(reserva => reserva.User.Id.ToString() == usuarioId).ToList();

    public async Task<Reservations> Get(string id) => await _reservas.FindByIdAsync(id);

    public async Task Create(Reservations reservation)
    {
       
        await _reservas.InsertOneAsync(reservation);
    }

    public async Task Update(Reservations reservation) => await _reservas.ReplaceOneAsync(reservation);

    public async void Remove(Reservations reservationInf) => await _reservas.DeleteOneAsync(reserva => reserva.Id == reservationInf.Id);
    
}
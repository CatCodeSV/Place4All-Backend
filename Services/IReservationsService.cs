using MongoDB.Bson;
using WebApi.Models;

namespace WebApi.Services;

public interface IReservationsService
{
    List<Reservations> Get();

    List<Reservations> GetUserReserva(string usuarioId);

    Task<Reservations> Get(string id);

    Task Create(Reservations reservation);

    Task Update(Reservations reservation);

    void Remove(Reservations reservationInf);

}
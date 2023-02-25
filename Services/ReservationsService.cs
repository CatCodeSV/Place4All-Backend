using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApi.Models;

namespace WebApi.Services;

public class ReservationsService
{
    private readonly IMongoCollection<Reservations> _reservas;

    public ReservationsService(IDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _reservas = database.GetCollection<Reservations>("Reservations");
    }

    public async Task<List<Reservations>> Get() => await _reservas.Find(reserva => true).ToListAsync();

    public async Task<List<Reservations>> GetUserReserva(string usuarioId) =>
      await  _reservas.Find(reserva => reserva.Users.Id == usuarioId).ToListAsync();

    public async Task<Reservations> Get(string id) => await _reservas.Find<Reservations>(reserva => reserva.Id == id).FirstOrDefaultAsync();

    public async Task Create(Reservations reservation)
    {
        reservation.Id ??= new BsonObjectId(ObjectId.GenerateNewId()).ToString();
        await _reservas.InsertOneAsync(reservation);
        return;
    }

    public async Task Update(string id, Reservations reservation) => await _reservas.ReplaceOneAsync(Builders<Reservations>.Filter.Eq(s => s.Id, id), reservation);

    public async void Remove(Reservations reservationInf) => await _reservas.DeleteOneAsync(reserva => reserva.Id == reservationInf.Id);
    
}
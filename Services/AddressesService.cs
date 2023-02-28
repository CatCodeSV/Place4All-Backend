using System.Collections.Generic;
using MongoDB.Bson;
using WebApi.Models;
using MongoDB.Driver;

namespace WebApi.Services
{
    public class AddressesService
    {
        private readonly IMongoCollection<Addresses> _direcciones;
        
        public AddressesService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _direcciones = database.GetCollection<Addresses>("Addresses");
        }

        public async Task<List<Addresses>> Get() => await _direcciones.Find(direccion => true).ToListAsync();

        public async Task<Addresses> Get(string id) => await _direcciones.Find<Addresses>(direccion => direccion.Id == id).FirstOrDefaultAsync();

        public async Task<Addresses> Create(Addresses address)
        {
            address.Id ??= new BsonObjectId(ObjectId.GenerateNewId()).ToString();
            await _direcciones.InsertOneAsync(address);
            return address;
        }

        public async void Update(string id, Addresses address) => await _direcciones.ReplaceOneAsync(Builders<Addresses>.Filter.Eq(s => s.Id, id), address);

        public async void Remove(Addresses address) => await _direcciones.DeleteOneAsync(direccion => direccion.Id == address.Id);


    }
}

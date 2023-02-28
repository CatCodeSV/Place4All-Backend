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

        public List<Addresses> Get() => _direcciones.Find(direccion => true).ToList();

        public Addresses Get(string id) => _direcciones.Find<Addresses>(direccion => direccion.Id == id).FirstOrDefault();

        public Addresses Create(Addresses address)
        {
            address.Id ??= new BsonObjectId(ObjectId.GenerateNewId()).ToString();
            _direcciones.InsertOne(address);
            return address;
        }

        public void Update(string id, Addresses address) => _direcciones.ReplaceOne(Builders<Addresses>.Filter.Eq(s => s.Id, id), address);

        public void Remove(Addresses address) => _direcciones.DeleteOne(direccion => direccion.Id == address.Id);

        internal Task<List<Addresses>> GetAddressesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

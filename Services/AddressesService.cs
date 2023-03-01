using MongoDB.Bson;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class AddressesService : IAddressesService
    {
        private readonly IMongoRepository<Addresses> _direcciones;
        
        public AddressesService(IMongoRepository<Addresses> addressRepository)
        {

            _direcciones = addressRepository;
        }

        public  List<Addresses> Get() =>  _direcciones.AsQueryable().ToList();

        public async Task<Addresses> Get(string id) => await _direcciones.FindByIdAsync(id);

        public async Task<Addresses> Create(Addresses address)
        {
            address.Id ??= new BsonObjectId(ObjectId.GenerateNewId()).AsObjectId;
            await _direcciones.InsertOneAsync(address);
            return address;
        }

        public async void Update(Addresses address) => await _direcciones.ReplaceOneAsync(address);

        public async void Remove(Addresses address) =>
            await _direcciones.DeleteOneAsync(direccion => direccion.Id == address.Id);
    }
}

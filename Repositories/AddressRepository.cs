using MongoDB.Driver;
using System.Collections.Immutable;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private AddressesService _addresses { get; set; }

        private readonly IMongoCollection<Addresses> _direcciones;
        AddressesService IAddressRepository._addresses { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private Addresses direccion;

        //public List<Addresses> Get() => _direcciones.Find(direccion => true).ToList();
        public async Task<List<Addresses>> Get()
        {
            await _direcciones.Find(direccion).ToList();
        }
            //return await _addresses.GetAddressesAsync();

        public async Task<Addresses> Get(string id)
        {
           await _direcciones.Find<Addresses>(direccion => direccion.Id == id).FirstOrDefaultAsync();
        }
      
        public async Task<Addresses> Create(Addresses address)
        {
            await address.Id=
        }

        public Task Update(string id, Addresses address)
        {
            throw new NotImplementedException();
        }

        public Task<Addresses> Remove(Addresses addresses)
        {
            throw new NotImplementedException();
        }

        internal object Find(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        internal void InsertOne(Addresses address)
        {
            throw new NotImplementedException();
        }

        internal void DeleteOne(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}

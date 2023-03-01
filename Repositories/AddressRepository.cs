using System.Collections.Immutable;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private AddressesService _addresses { get; set; }
        AddressesService IAddressRepository._addresses { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private Addresses direccion;

        //public List<Addresses> Get() => _direcciones.Find(direccion => true).ToList();
        public async Task<List<Addresses>> Get()
        {
            return await _addresses.GetAddressesAsync();
        }
}
}

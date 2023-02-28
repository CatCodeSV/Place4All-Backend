using WebApi.Models;
using WebApi.Services;

namespace WebApi.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private AddressesService _addresses { get; set; }

        AddressesService IAddressRepository_addresses;


        private Addresses direccion;

        public async Task<List<Addresses>> Get()
        {
            return await _addresses.GetAddressesAsync();
        }
}
}

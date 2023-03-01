using WebApi.Models;
using WebApi.Services;

namespace WebApi.Repositories
{
    public interface IAddressRepository
    {
        public AddressesService _addresses { get; set; }

        public Task<List<Addresses>> GetAddressesAsync()
        {
            throw new NotImplementedException();
        }

    }
}

using WebApi.Models;
using WebApi.Services;

namespace WebApi.Repositories
{
    public interface IAddressRepository
    {
        public AddressesService _addresses { get; set; }

        public Task<List<Addresses>> Get();

        public Task<Addresses> Get(string id);

        public Task <Addresses> Create(Addresses address);

        public Task Update(string id, Addresses address);

        public Task<Addresses> Remove(Addresses addresses);

        //public Task<List<Addresses>> GetAddressesAsync()
        //{
        //    throw new NotImplementedException();
        //}


    }
}

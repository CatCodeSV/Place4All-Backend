using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IAddressRepository
    {
        public Task<List<Addresses>> Get();
    }
}

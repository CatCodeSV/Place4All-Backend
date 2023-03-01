using WebApi.Models;

namespace WebApi.Services;

public interface IAddressesService
{
    List<Addresses> Get();

    Task<Addresses> Get(string id);

    Task<Addresses> Create(Addresses address);

    void Update(Addresses address);

    void Remove(Addresses address);
}
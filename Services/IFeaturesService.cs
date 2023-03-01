using WebApi.Models;

namespace WebApi.Services;

public interface IFeaturesService
{
    List<Features> Get();

    Task<Features> Get(string id);

    Task<Features> Create(Features feature);

    void Update(Features feature);

    void Remove(Features feature);
}
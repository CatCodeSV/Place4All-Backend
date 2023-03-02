using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class FeaturesService: IFeaturesService
{
    private readonly IMongoRepository<Features> _servicios;
    public FeaturesService(IMongoRepository<Features> repository)
    {

        _servicios = repository;
    }

    public List<Features> Get() =>
        _servicios.AsQueryable().ToList();

    public async Task<Features> Get(string id) =>
        await _servicios.FindByIdAsync(id);

    public async Task<Features> Create(Features feature)
    {
        //Preguntar donde debería ir esta lógica
        await _servicios.InsertOneAsync(feature);
        return feature;
    }

    public void Update(Features feature)
    {
        _servicios.ReplaceOneAsync(feature);
    }

    public async void Remove(Features feature) =>
        await _servicios.DeleteOneAsync(servicio => servicio.Id == feature.Id);
}
}
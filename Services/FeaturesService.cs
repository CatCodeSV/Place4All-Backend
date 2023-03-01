using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using WebApi.Models;

namespace WebApi.Services
{
    public class FeaturesService
{
    private readonly IMongoCollection<Features> _servicios;
    public FeaturesService(IDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _servicios = database.GetCollection<Features>("Features");
    }

    public async Task<List<Features>> Get() =>
       await _servicios.Find(servicio => true).ToListAsync();

    public async Task<Features> Get(string id) =>
        await _servicios.Find<Features>(servicio => servicio.Id == id).FirstOrDefaultAsync();

    public async Task<Features> Create(Features feature)
    {
        //Preguntar donde debería ir esta lógica
        feature.Id ??= new BsonObjectId(ObjectId.GenerateNewId()).ToString();
        await _servicios.InsertOneAsync(feature);
        return feature;
    }

    public async void Update(string id, Features feature)
    {
        await _servicios.ReplaceOneAsync(Builders<Features>.Filter.Eq(s => s.Id, id), feature);
    }

    public async void Remove(Features feature) =>
        await _servicios.DeleteOneAsync(servicio => servicio.Id == feature.Id);
}
}
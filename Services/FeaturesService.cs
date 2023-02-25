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

    public List<Features> Get() =>
        _servicios.Find(servicio => true).ToList();

    public Features Get(string id) =>
        _servicios.Find<Features>(servicio => servicio.Id == id).FirstOrDefault();

    public Features Create(Features feature)
    {
        //Preguntar donde debería ir esta lógica
        feature.Id ??= new BsonObjectId(ObjectId.GenerateNewId()).ToString();
        _servicios.InsertOne(feature);
        return feature;
    }

    public void Update(string id, Features feature)
    {
        _servicios.ReplaceOne(Builders<Features>.Filter.Eq(s => s.Id, id), feature);
    }

    public void Remove(Features feature) =>
        _servicios.DeleteOne(servicio => servicio.Id == feature.Id);
}
}
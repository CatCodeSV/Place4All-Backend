using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApi.Models;
using BsonObjectId = MongoDB.Bson.BsonObjectId;

namespace WebApi.Services;

public class ReviewsService
{
    private readonly IMongoCollection<Reviews> _reviews;

    //Conectamos la base de datos con usuarios
    public ReviewsService(IDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _reviews = database.GetCollection<Reviews>("Reviews");
    }
    
    //Recoge todas las reviews por restaurante
    public async Task<List<Reviews>> GetByRestaurant(string restaurantId) =>
        await _reviews.Find(review => review.Restaurant.Id == restaurantId).ToListAsync();
    
    //Recoge todas las reviews por usuario
    public async Task<List<Reviews>> GetByUser(string userId) =>
        await _reviews.Find(review => review.User.Id == userId).ToListAsync();
    
    //Busca una review por ID
    public async Task<Reviews> GetById(string reviewId) =>
        await _reviews.Find(review => review.Id == reviewId).FirstOrDefaultAsync();

    public async Task<Reviews> Create(Reviews review)
    {
        review.Id ??= new BsonObjectId(ObjectId.GenerateNewId()).ToString();
        await _reviews.InsertOneAsync(review);
        return review;
    }
}
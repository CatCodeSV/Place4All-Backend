using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApi.Models;
using WebApi.Repositories;
using BsonObjectId = MongoDB.Bson.BsonObjectId;

namespace WebApi.Services;

public class ReviewsService: IReviewsService
{
    private readonly IMongoRepository<Reviews> _reviews;

    //Conectamos la base de datos con usuarios
    public ReviewsService(IMongoRepository<Reviews> settings)
    {
        _reviews = settings;
    }
    
    //Recoge todas las reviews por restaurante
    public List<Reviews> GetByRestaurant(string restaurantId) =>
        _reviews.AsQueryable().ToList();
    
    //Recoge todas las reviews por usuario
    public List<Reviews> GetByUser(string userId) =>
        _reviews.FilterBy(review => review.User.Id.ToString() == userId).ToList();
    
    //Busca una review por ID
    public async Task<Reviews> GetById(string reviewId) =>
        await _reviews.FindByIdAsync(reviewId);

    public async Task<Reviews> Create(Reviews review)
    {
        review.Id ??= new BsonObjectId(ObjectId.GenerateNewId()).AsObjectId;
        await _reviews.InsertOneAsync(review);
        return review;
    }
}
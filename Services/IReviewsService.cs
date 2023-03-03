using WebApi.Models;

namespace WebApi.Services;

public interface IReviewsService
{
    List<Reviews> GetByRestaurant(string restaurantId);
        
    
    //Recoge todas las reviews por usuario
    List<Reviews> GetByUser(string userId);
    
    
    //Busca una review por ID
    Task<Reviews> GetById(string reviewId);

    Task<Reviews> Create(Reviews review);
}
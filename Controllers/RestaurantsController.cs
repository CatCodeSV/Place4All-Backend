using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Restaurants")]
    
    public class RestaurantsController : ControllerBase
    {

        private readonly IRestaurantsService _servicioRestaurante;
        private readonly IAddressesService _addressesService;
        private readonly IReviewsService _reviewsService;

        public RestaurantsController(IRestaurantsService servicioRestaurante, IAddressesService addressesService, IReviewsService reviewsService)
        {
            _servicioRestaurante = servicioRestaurante;
            _addressesService = addressesService;
            _reviewsService = reviewsService;
        }

        [HttpGet]
        public ActionResult<List<RestaurantReviews>> Get()
        {
            var restaurants = _servicioRestaurante.Get();
            List<RestaurantReviews> lists = new List<RestaurantReviews>();
            foreach (var restaurant in restaurants)
            {
                var reviews = _reviewsService.GetByRestaurant(restaurant.Id.ToString());
                double reviewsSum = 0.0;
                double reviewsAverage = 0;
                reviews.ForEach(review =>
                {
                    reviewsSum += review.Value;
                });
                if (reviews.Count != 0 && reviewsSum != 0)
                {
                    reviewsAverage = reviewsSum / reviews.Count;
                }
                
                lists.Add(
                        new RestaurantReviews
                        {
                            Id = restaurant.Id,
                            Name = restaurant.Name,
                            Address = restaurant.Address,
                            Descripcion = restaurant.Descripcion,
                            Image = restaurant.Image,
                            PhoneNumber = restaurant.PhoneNumber,
                            Servicio = restaurant.Servicio,
                            ReviewsAverage = reviewsAverage,
                            ReviewsNumber = reviews.Count
                        }
                    );
            }

            return lists;
        }

        //Se pasa por la URL un id que tiene que tener 24 caracteres ya que el BSON.Id tiene ese formato.
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Restaurants>> Get(string id)
        {
            var restaurante =await _servicioRestaurante.Get(id);

            if (restaurante == null)
            {
                return NotFound();
            }

            return restaurante;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Restaurants>> Create(Restaurants restaurant)
        {
            var restauranteD = await HasDireccion(restaurant);
            var restauranteCreado = await _servicioRestaurante.Create(restauranteD);

            return CreatedAtRoute("", new { id = restaurant.Id }, restauranteCreado);
        }

        [Authorize]
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, Restaurants restaurant)
        {
            var restaurante = await _servicioRestaurante.Get(id);

            if (restaurante == null)
            {
                return NotFound();
            }

            restaurant.Id = restaurante.Id;
            _servicioRestaurante.Update(restaurant);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var restaurante =await _servicioRestaurante.Get(id);


            if (restaurante == null)
            {
                return NotFound();
            }
            DeleteDireccion(restaurante);
             _servicioRestaurante.Delete(restaurante);

            return NoContent();
        }
        
        [HttpPost("search")]
        public async Task Search(IBuscaCiudad ciudad) => _servicioRestaurante.Search(ciudad);
        
        private async Task<Restaurants> HasDireccion (Restaurants restaurant)
        {
            if(restaurant.Address.Id == null)
            {
                var DireccionD =await _addressesService.Create(restaurant.Address);
                restaurant.Address = DireccionD;
                return restaurant;
            }

            var direccion =await _addressesService.Get(restaurant.Address.Id.ToString());
            if (direccion != null) return restaurant;
            
            direccion = await _addressesService.Create(restaurant.Address);
            restaurant.Address = direccion;
            return restaurant;

        }

        private  void DeleteDireccion (Restaurants restaurant)
        {
           _addressesService.Remove(restaurant.Address);
        }
    }
}

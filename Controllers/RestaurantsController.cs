using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Restaurants")]
    
    public class RestaurantsController : ControllerBase
    {

        private readonly RestaurantsService _servicioRestaurante;
        private readonly AddressesService _addressesService;

        public RestaurantsController(RestaurantsService servicioRestaurante, AddressesService addressesService)
        {
            _servicioRestaurante = servicioRestaurante;
            _addressesService = addressesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Restaurants>>> Get() =>await _servicioRestaurante.Get();

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

        [HttpPost]
        public async Task<ActionResult<Restaurants>> Create(Restaurants restaurant)
        {
            var restauranteD = await HasDireccion(restaurant);
            var restauranteCreado = await _servicioRestaurante.Create(restauranteD);

            return CreatedAtRoute("", new { id = restaurant.Id }, restauranteCreado);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, Restaurants restaurant)
        {
            var restaurante = await _servicioRestaurante.Get(id);

            if (restaurante == null)
            {
                return NotFound();
            }

            restaurant.Id = restaurante.Id;
            _servicioRestaurante.Update(id, restaurant);

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
        public async Task Search(IBuscaCiudad ciudad) => await _servicioRestaurante.Search(ciudad);
        
        private async Task<Restaurants> HasDireccion (Restaurants restaurant)
        {
            if(restaurant.Address.Id == null)
            {
                var DireccionD =await _addressesService.Create(restaurant.Address);
                restaurant.Address = DireccionD;
                return restaurant;
            }

            var direccion =await _addressesService.Get(restaurant.Address.Id);
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

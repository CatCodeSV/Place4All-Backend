using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class RestaurantsService: IRestaurantsService
    {
        //Damos a la lista de Restaurantes el nombre de _restaurantes
        private readonly IMongoRepository<Restaurants> _restaurantes;

        //Conexión de la base de datos con los objetos restaurantes
        public RestaurantsService(IMongoRepository<Restaurants> settings)
        {

            _restaurantes = settings;
        }

        //Método que recoge todos los objetos restaurant de la base de datos y los devuelve en forma de lista
        public List<Restaurants> Get() => _restaurantes.AsQueryable().ToList();

        //Método que busca en la base dTask<e> datos y devuelve el objeto restaurant con la id introducida por parámetro
        public async Task<Restaurants> Get(string id) => await _restaurantes.FindByIdAsync(id);

        //Método que crea un objeto restaurant
        public async Task<Restaurants> Create(Restaurants restaurant)
        {
            //Comprobación, si el restaurant nuevo no contiene un Id (al crearse en el constructor nulo), entonces se genera uno nuevo y se le asigna
           
            //Inserta un objeto restaurant en el listado de todos los restaurantes de la bd
           await   _restaurantes.InsertOneAsync(restaurant);
            //Devuelve el restaurant recién creado
            return restaurant;
        }

        //Actualizamos la lista de restaurantes al insertar nuevo restaurant
        public async Task Update(Restaurants restaurant) => await _restaurantes.ReplaceOneAsync(restaurant);

        //Borramos el restaurant pasado como parámetro de entrada de la lista de restaurantes de la bd identificándolo mediante su Id
        public async Task Delete(Restaurants restaurant) => await  _restaurantes.DeleteOneAsync(restaurante => restaurante.Id == restaurant.Id);

        public List<Restaurants> Search(IBuscaCiudad busqueda) => _restaurantes
            .FilterBy(restaurante => restaurante.Address.City.ToLower() == busqueda.Ciudad.ToLower()).ToList();
    }
}

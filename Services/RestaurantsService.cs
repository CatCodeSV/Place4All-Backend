using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApi.Models;

namespace WebApi.Services
{
    public class RestaurantsService
    {
        //Damos a la lista de Restaurantes el nombre de _restaurantes
        private readonly IMongoCollection<Restaurants> _restaurantes;

        //Conexión de la base de datos con los objetos restaurantes
        public RestaurantsService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _restaurantes = database.GetCollection<Restaurants>("Restaurants");
        }

        //Método que recoge todos los objetos restaurant de la base de datos y los devuelve en forma de lista
        public async Task<List<Restaurants>> Get() => await _restaurantes.Find(restaurante => true).ToListAsync();

        //Método que busca en la base dTask<e> datos y devuelve el objeto restaurant con la id introducida por parámetro
        public async Task<Restaurants> Get(string id) => await  _restaurantes.Find(restaurante => restaurante.Id == id).FirstOrDefaultAsync();

        //Método que crea un objeto restaurant
        public async Task<Restaurants> Create(Restaurants restaurant)
        {
            //Comprobación, si el restaurant nuevo no contiene un Id (al crearse en el constructor nulo), entonces se genera uno nuevo y se le asigna
            restaurant.Id ??= new BsonObjectId(ObjectId.GenerateNewId()).ToString();
            //Inserta un objeto restaurant en el listado de todos los restaurantes de la bd
           await   _restaurantes.InsertOneAsync(restaurant);
            //Devuelve el restaurant recién creado
            return restaurant;
        }

        //Actualizamos la lista de restaurantes al insertar nuevo restaurant
        public async Task Update(string id, Restaurants restaurant) =>  await _restaurantes.ReplaceOneAsync(Builders<Restaurants>.Filter.Eq(r => r.Id, id), restaurant);

        //Borramos el restaurant pasado como parámetro de entrada de la lista de restaurantes de la bd identificándolo mediante su Id
        public async Task Delete(Restaurants restaurant) => await  _restaurantes.DeleteOneAsync(restaurante => restaurante.Id == restaurant.Id);

        public async Task<List<Restaurants>> Search(IBuscaCiudad busqueda) => await  _restaurantes
            .Find(restaurante => restaurante.Address.City.ToLower() == busqueda.Ciudad.ToLower()).ToListAsync();
    }
}

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
        public List<Restaurants> Get() => _restaurantes.Find(restaurante => true).ToList();

        //Método que busca en la base de datos y devuelve el objeto restaurant con la id introducida por parámetro
        public Restaurants Get(string id) => _restaurantes.Find(restaurante => restaurante.Id == id).FirstOrDefault();

        //Método que crea un objeto restaurant
        public Restaurants Create(Restaurants restaurant)
        {
            //Comprobación, si el restaurant nuevo no contiene un Id (al crearse en el constructor nulo), entonces se genera uno nuevo y se le asigna
            restaurant.Id ??= new BsonObjectId(ObjectId.GenerateNewId()).ToString();
            //Inserta un objeto restaurant en el listado de todos los restaurantes de la bd
            _restaurantes.InsertOne(restaurant);
            //Devuelve el restaurant recién creado
            return restaurant;
        }

        //Actualizamos la lista de restaurantes al insertar nuevo restaurant
        public void Update(string id, Restaurants restaurant) => _restaurantes.ReplaceOne(Builders<Restaurants>.Filter.Eq(r => r.Id, id), restaurant);

        //Borramos el restaurant pasado como parámetro de entrada de la lista de restaurantes de la bd identificándolo mediante su Id
        public void Delete(Restaurants restaurant) => _restaurantes.DeleteOne(restaurante => restaurante.Id == restaurant.Id);

        public Task<List<Restaurants>> Search(IBuscaCiudad busqueda) => _restaurantes
            .Find(restaurante => restaurante.Addresses.City.ToLower() == busqueda.Ciudad.ToLower()).ToListAsync();
    }
}

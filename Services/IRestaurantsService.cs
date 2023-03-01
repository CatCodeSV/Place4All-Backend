using MongoDB.Bson;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services;

public interface IRestaurantsService
{
    //Método que recoge todos los objetos restaurant de la base de datos y los devuelve en forma de lista
    List<Restaurants> Get();

    //Método que busca en la base dTask<e> datos y devuelve el objeto restaurant con la id introducida por parámetro
    Task<Restaurants> Get(string id);

    //Método que crea un objeto restaurant
    Task<Restaurants> Create(Restaurants restaurant);

    //Actualizamos la lista de restaurantes al insertar nuevo restaurant
    Task Update(Restaurants restaurant);

    //Borramos el restaurant pasado como parámetro de entrada de la lista de restaurantes de la bd identificándolo mediante su Id
    Task Delete(Restaurants restaurant);

    List<Restaurants> Search(IBuscaCiudad busqueda);
}
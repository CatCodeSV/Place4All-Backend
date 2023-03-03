using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Services;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Name de la politica
            var  myAllowSpecificOrigins = "_myAllowSpecificOrigins";
            //Creación del contenedor de la aplicación llamado builder
            var builder = WebApplication.CreateBuilder(args);

            //Creamos la politica de CORS
            builder.Services.AddCors(options =>
            {
                //Le añadimos un el nombre que hemos creado arriba
                options.AddPolicy(name: myAllowSpecificOrigins, policy =>
                {
                    //Todos los headers, todos los métodos y todos los origines
                    //TODO Restringir el origen de las llamadas
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            //Configuración de la base de datos en el contenedor builder
            builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));

            //Para evitar errores en la ejecución de la API
            builder.Services.AddMvc(options =>
            {
                //Método que cuando es true recorta el sufijo Async aplicado en los métodos
                options.SuppressAsyncSuffixInActionNames = false;
            });

            //Permite el acceso de los servicios a la base de datos
            builder.Services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            //Añadir cada servicio de la siguiente manera: services.AddSingleton<{Name del servicio}>();
            builder.Services.AddTransient<IFeaturesService, FeaturesService>();
            builder.Services.AddTransient<IUsersService, UsersService>();
            builder.Services.AddTransient<IRestaurantsService, RestaurantsService>();
            builder.Services.AddTransient<IReservationsService, ReservationsService>();
            builder.Services.AddTransient<IAddressesService,AddressesService>();
            builder.Services.AddTransient(typeof(IMongoRepository<>), typeof(MongoDBRepository<>));
            
            //Añade los controladores de los servicios
            builder.Services.AddControllers();

            //Añade un documento swagger para controlar la API
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });

            //Tras realizar los pasos anteriores se ejecuta el builder
            var app = builder.Build();
            
            //Configuración de las peticiones con HTTP
            if (builder.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(myAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
        
        
    }
}


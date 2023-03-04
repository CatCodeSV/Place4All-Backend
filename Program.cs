using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using WebApi.Models;
using WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Entities;
using WebApi.Persistence;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;

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

            //builder.Services
            //    .AddSqlite<MyDbContext>(builder.Configuration.GetConnectionString("Default"))
            //    .AddIdentityCore<Entities.User>()
            //    .AddRoles<IdentityRole>();
            //    .AddEntityFrameworkStores<MyDbContext>();

            builder.Services
                .AddHttpContextAccessor()
                .AddAuthorization()
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(optiens =>
                {
                    optiens.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"].ToString()))
                    };
                });

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

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            //Para evitar errores en la ejecución de la API
            builder.Services.AddMvc(options =>
            {
                //Método que cuando es true recorta el sufijo Async aplicado en los métodos
                options.SuppressAsyncSuffixInActionNames = false;
            });

            //Permite el acceso de los servicios a la base de datos
            builder.Services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            //Añadir cada servicio de la siguiente manera: services.AddSingleton<{Name del servicio}>();
            builder.Services.AddSingleton<FeaturesService>();
            builder.Services.AddSingleton<AddressesService>();
            builder.Services.AddSingleton<UsersService>();
            builder.Services.AddSingleton<RestaurantsService>();
            builder.Services.AddSingleton<ReservationsService>();
            
            //Añade los controladores de los servicios
            builder.Services.AddControllers();

            //Añade un documento swagger para controlar la API
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });

            //TODO (Autentificación JWT)
            builder.Services.AddScoped<UsersService>();

            //Tras realizar los pasos anteriores se ejecuta el builder
            var app = builder.Build();

            //TODO (Autentificación JWT)
            app.UseAuthentication();
            
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


using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;

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
            // Logger
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
                    .Build();

            var logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            builder.Host.UseSerilog();
            builder.Services
                .AddHttpContextAccessor()
                .AddAuthorization()
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
            builder.Services.AddTransient<IReviewsService, ReviewsService>();
            builder.Services.AddTransient(typeof(IMongoRepository<>), typeof(MongoDBRepository<>));
            
            //Añade los controladores de los servicios
            builder.Services.AddControllers();

            //Añade un documento swagger para controlar la API
            builder.Services.AddSwaggerGen(c =>
            {
                var securitySchema = new OpenApiSecurityScheme()
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securitySchema.Reference.Id, securitySchema);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securitySchema, Array.Empty<string>() }
                });
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

            Log.CloseAndFlush();
            app.Run();
        }

    }
}


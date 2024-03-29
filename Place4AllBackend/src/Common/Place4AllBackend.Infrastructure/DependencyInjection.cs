﻿using System;
using System.Reflection;
using System.Text;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Infrastructure.Identity;
using Place4AllBackend.Infrastructure.Persistence;
using Place4AllBackend.Infrastructure.Services;
using Place4AllBackend.Infrastructure.Services.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Place4AllBackend.Application.Mapping;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration) //, IWebHostEnvironment environment)
        {
            var provider = configuration.GetValue("DbProvider", "SqlServer");
            var migrationAssembly = $"Place4AllBackend.Infrastructure.{provider}";
            services.AddDbContext<ApplicationDbContext>(options => _ = provider switch
            {
                "Sqlite" => options.UseSqlite(
                    configuration.GetConnectionString("DefaultConnection_Sqlite"),
                    b => { b.MigrationsAssembly(migrationAssembly); }),

                "SqlServer" => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b =>
                    {
                        b.MigrationsAssembly(migrationAssembly);
                        b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    }),

                "Npgsql" => options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection_Postgres"),
                    b => { b.MigrationsAssembly(migrationAssembly); }),

                _ => throw new Exception($"Unsupported provider: {provider}")
            });

            services.AddScoped<IApplicationDbContext>(serviceProvider =>
                serviceProvider.GetService<ApplicationDbContext>());

            services.AddScoped<IDomainEventService, DomainEventService>();

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddHttpClient("open-weather-api", c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("OpenWeatherApi:Url").Value);

                c.DefaultRequestHeaders.Add(configuration.GetSection("OpenWeatherApi:Key:Key").Value,
                    configuration.GetSection("OpenWeatherApi:Key:Value").Value);

                c.DefaultRequestHeaders.Add(configuration.GetSection("OpenWeatherApi:Host:Key").Value,
                    configuration.GetSection("OpenWeatherApi:Host:Value").Value);
            });

            services.AddTransient<IHttpClientHandler, HttpClientHandler>();
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IOpenWeatherService, OpenWeatherService>();
            services.AddTransient<ITokenService, TokenService>();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = configuration["JWT:ValidAudience"],
                        ValidIssuer = configuration["JWT:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                    };
                })
                .AddIdentityServerJwt();

            return services;
        }
    }
}
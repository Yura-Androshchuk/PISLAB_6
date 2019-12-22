using AutoMapper;
using Dal;
using Dal.Interfaces;
using Dal.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BusinessLogic.Interfaces;
using BusinessLogic.Servicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRegistration.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        
public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }


        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnextion"];


            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>(ServiceProvider =>
            {
                return new RepositoryWrapper(connectionString);
            });

        }
        public static void ConfigureBLLServices(this IServiceCollection services)
        {
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IIngredientService, IngredientService>();
            
        }
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }


    }
}

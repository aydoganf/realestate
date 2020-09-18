using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using REModel.DatabaseConnection.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Domain.Repositories;
using TestApi.Repositories;
using TestApi.Services;

namespace TestApi.Mongo
{
    public static class Extensions
    {
        public static void AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoOptions>(configuration.GetSection("mongo"));
            services.AddSingleton<MongoClient>(c =>
            {
                var options = c.GetService<IOptions<MongoOptions>>().Value;

                return new MongoClient(options.ConnectionString);
            });

            services.AddScoped<IMongoDatabase>(c =>
            {
                var options = c.GetService<IOptions<MongoOptions>>().Value;
                var client = c.GetService<MongoClient>();

                return client.GetDatabase(options.Database);
            });

            services.AddScoped<IMongoInitializer, MongoInitializer>();
            services.AddScoped<IDatabaseSeeder, MongoSeeder>();
            services.AddScoped<IDatabaseSeeder, CustomMongoSeeder>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.BuildServiceProvider().GetService<IMongoInitializer>().InitializeAsync();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using MongoDB.ApplicationInsights.DependencyInjection;

namespace Prismatic.Core.Infra
{
    public static class MongoExtensions
    {
        public static void ConfigureMongoClient(this WebApplicationBuilder builder)
        {
            var mongoPassword = 
                Environment.GetEnvironmentVariable("MONGO_PASSWORD") 
                ?? 
                throw new Exception("Environment Variable MONGO_PASSWORD not declared");

            var connectionString = builder.Configuration.GetConnectionString("MongoDb");
            builder.Services.AddMongoClient(connectionString.Replace("MONGO_PASSWORD", mongoPassword));
        }
    }
}

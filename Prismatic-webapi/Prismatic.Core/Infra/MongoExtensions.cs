using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using MongoDB.ApplicationInsights.DependencyInjection;

namespace Prismatic.Core.Infra
{
    public static class MongoExtensions
    {
        public static void ConfigureMongoClient(this WebApplicationBuilder builder)
        {
            var mongoPassword = Environment.GetEnvironmentVariable("MONGO_PASSWORD");
            builder.Services.AddMongoClient(builder.Configuration.GetConnectionString("MongoDb").Replace("MONGO_PASSWORD", mongoPassword));
        }
    }
}

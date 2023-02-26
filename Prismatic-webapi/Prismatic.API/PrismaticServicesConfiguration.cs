using Prismatic.Domain.Interfaces;
using Prismatic.Domain.Repositories;

namespace Prismatic.API
{
    public static class PrismaticServicesConfiguration
    {
        public static void ConfigurePrismaticServices(this IServiceCollection services)
        {
            services.AddTransient<IMatchRepository, MatchRepository>();
        }
    }
}

using Prismatic.Domain.Repositories;
using Prismatic.Infra.Hubs;
using Prismatic.Infra.Repositories;

namespace Prismatic.API
{
    public static class PrismaticServicesConfiguration
    {
        public static void ConfigurePrismaticServices(this IServiceCollection services)
        {
            services.AddTransient<ILobbyRepository, LobbyRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
        }

        public static void UsePrismaticHubs(this WebApplication app)
        {
            app.MapHub<MatchHub>("/match");
            app.MapHub<LobbyHub>("/lobby");
        }
    }
}

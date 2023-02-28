using MediatR;
using Prismatic.Application.Lobbies;
using Prismatic.Core.Api;
using Prismatic.Domain.Entities;

namespace Prismatic.API.Endpoints.Lobbies
{
    public class JoinLobby : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapPost("lobby/{id}", Handler).WithOpenApi();
        }

        public async Task Handler(IMediator mediator, Guid lobbyId, Player player)
        {
            await mediator.Send(new JoinLobbyRequest(player, lobbyId));
        }
    }
}
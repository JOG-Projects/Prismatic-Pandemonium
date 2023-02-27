using MediatR;
using Prismatic.Application.Lobbies;
using Prismatic.Core.Api;
using Prismatic.Domain.Entities;

namespace Prismatic.API.Endpoints.Lobbies
{
    public class CreateLobby : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("lobby/create", Handler).WithOpenApi();
        }

        public async Task Handler(IMediator mediator, Player owner)
        {
            await mediator.Send(new CreateLobbyRequest(owner));
        }
    }
}
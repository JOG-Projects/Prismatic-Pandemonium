using MediatR;
using Prismatic.Application.Lobbies;
using Prismatic.Core.Api;

namespace Prismatic.API.Endpoints.Lobbies
{
    public class CreateLobby : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapPost("lobby", Handler).WithOpenApi();
        }

        public async Task<Guid> Handler(IMediator mediator, Guid ownerId)
        {
            return await mediator.Send(new CreateLobbyRequest(ownerId));
        }
    }
}
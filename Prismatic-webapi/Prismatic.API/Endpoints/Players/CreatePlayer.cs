using MediatR;
using Prismatic.Application.Players;
using Prismatic.Core.Api;

namespace Prismatic.API.Endpoints.Players
{
    public class CreatePlayer : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapPost("player", Handler).WithOpenApi();
        }

        public async Task Handler(IMediator mediator, string username)
        {
            await mediator.Send(new CreatePlayerRequest(username));
        }
    }
}
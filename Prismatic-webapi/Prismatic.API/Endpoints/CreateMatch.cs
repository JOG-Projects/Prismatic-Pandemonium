using Prismatic.Core.Api;

namespace Prismatic.API.Endpoints
{
    public class CreateMatch : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("match/create", () =>
            {
                throw new Exception("bizarro...");
            });
        }
    }
}
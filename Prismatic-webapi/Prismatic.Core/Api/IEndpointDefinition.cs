using Microsoft.AspNetCore.Builder;

namespace Prismatic.Core.Api
{
    public interface IEndpointDefinition
    {
        void DefineEndpoints(WebApplication app);
    }
}
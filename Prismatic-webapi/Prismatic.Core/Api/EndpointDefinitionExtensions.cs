using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Prismatic.Core.Api
{
    public static class EndpointDefinitonExtensions
    {
        public static void UseCustomExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    context.Response.ContentType = System.Net.Mime.MediaTypeNames.Application.Json;

                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>()!;

                    var json = JsonConvert.SerializeObject(exceptionHandlerPathFeature.Error, Formatting.Indented);

                    await context.Response.WriteAsync(json);
                });
            });
        }

        public static void UseEndpointDefinitions(this WebApplication app, params Type[] types)
        {
            var definitions = types
                .Select(t => GetEndpointsTypes(t)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinition>())
                .SelectMany(d => d);

            foreach (var endpointDefinition in definitions)
            {
                endpointDefinition.DefineEndpoints(app);
            }
        }

        private static IEnumerable<Type> GetEndpointsTypes(Type type)
        {
            return type.Assembly.ExportedTypes.Where(x => typeof(IEndpointDefinition).IsAssignableFrom(x) && !x.IsInterface);
        }
    }
}
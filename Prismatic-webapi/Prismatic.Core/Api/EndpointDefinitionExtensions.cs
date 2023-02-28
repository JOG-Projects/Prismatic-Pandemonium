using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Reflection;

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

        public static void UseEndpointDefinitions(this WebApplication app)
        {
            var definitions = GetEndpointsTypes().Select(Activator.CreateInstance).Cast<IEndpointDefinition>();

            foreach (var endpointDefinition in definitions)
            {
                endpointDefinition.DefineEndpoints(app);
            }
        }

        private static IEnumerable<Type> GetEndpointsTypes()
        {
            var types = Assembly.GetEntryAssembly()!.ExportedTypes;
            return types.Where(t => typeof(IEndpointDefinition).IsAssignableFrom(t) && !t.IsInterface);
        }
    }
}
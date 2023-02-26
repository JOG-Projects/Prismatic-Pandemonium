using Prismatic.Core.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseEndpointDefinitions();
app.UseCustomExceptionHandler();

app.MapGet("/endpoint", () =>
{
    throw new Exception("bizarro...");
});

app.Run();
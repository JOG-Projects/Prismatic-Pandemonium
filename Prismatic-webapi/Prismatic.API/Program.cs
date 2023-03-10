using Prismatic.API;
using Prismatic.Application;
using Prismatic.Core.Api;
using Prismatic.Core.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddSignalR();
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining(typeof(HandlersAssemblyMark)));
builder.Services.ConfigurePrismaticServices();
builder.ConfigureMongoClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseEndpointDefinitions();
app.UseCustomExceptionHandler();
app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UsePrismaticHubs();

app.Run();
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using TimeCapsule.Data;
using TimeCapsule.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TimeCapsuleDb>(options =>
{
    options.UseInMemoryDatabase("TimeCapsuleDb");
});

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
builder.Services.AddTimeCapsuleServices();

var app = builder.Build();

app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerGen();

app.Run();

using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using TimeCapsule.Data;
using TimeCapsule.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Db Setup
builder.Services.AddDbContext<TimeCapsuleDb>(options =>
{
    options.UseInMemoryDatabase("TimeCapsuleDb");
});

// FastEndpoints Setup
builder.Services
    .AddAuthenticationJwtBearer(s => s.SigningKey = "supersecret")
    .AddAuthorization()
    .AddFastEndpoints()
    .AddResponseCaching()
    .SwaggerDocument();

// TimeCapsule Services
builder.Services.AddTimeCapsuleServices();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCaching();
app.UseFastEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerGen();
}


app.Run();

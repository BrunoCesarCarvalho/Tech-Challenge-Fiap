using Microsoft.OpenApi.Models;
using TechChallengeFIAP.Domain.Configurations;
using TechChallengeFIAP.Domain.Interfaces.Repositories;
using TechChallengeFIAP.Domain.Interfaces.Services;
using TechChallengeFIAP.Domain.Services;
using TechChallengeFIAP.Infra.Configurations;
using TechChallengeFIAP.Infra.Context;
using TechChallengeFIAP.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurationInfra(builder.Configuration);
builder.Services.ConfigurationDomain();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Makes the Swagger UI the default page
});

// Redirect to Swagger when accessing the root URL
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }

    await next();
});

app.Run();

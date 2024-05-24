using Microsoft.OpenApi.Models;
using TechChallengeFIAP.Core.Configurations;
using TechChallengeFIAP.Domain.Configurations;
using TechChallengeFIAP.Infra.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.ConfigurationInfra(builder.Configuration);
builder.Services.ConfigurationDomain();
builder.Services.ConfigurationCore();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechChallengeFiap", Version = "v1" });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechChallengeFiap V1");
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



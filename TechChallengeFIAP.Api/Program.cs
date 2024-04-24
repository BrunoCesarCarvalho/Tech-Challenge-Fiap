using TechChallengeFIAP.Domain.Configurations;
using TechChallengeFIAP.Domain.Interfaces.Repositories;
using TechChallengeFIAP.Domain.Interfaces.Services;
using TechChallengeFIAP.Domain.Services;
using TechChallengeFIAP.Infra.Configurations;
using TechChallengeFIAP.Infra.Context;
using TechChallengeFIAP.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigurationInfra(builder.Configuration);
builder.Services.ConfigurationDomain();


//builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
//builder.Services.AddScoped<IProdutoService, ProdutoService>();
//builder.Services.AddScoped<DataBaseContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

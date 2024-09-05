using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechChallengeFIAP.Domain.InterfacesUserCases.Repositories;
using TechChallengeFIAP.Infra.Context;
using TechChallengeFIAP.Infra.Repositories;

namespace TechChallengeFIAP.Infra.Configurations
{
    public static class ConfigureInfra
    {
        public static void ConfigurationInfra(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IProdutoRepository, ProdutoRepository>();
            serviceCollection.AddScoped<IClienteRepository, ClienteRepository>();
            serviceCollection.AddScoped<IPedidoRepository, PedidoRepository>();
            serviceCollection.AddScoped<IPedidoProdutosRepository, PedidoProdutosRepository>();

            var conn = configuration.GetConnectionString("DataBase");
            serviceCollection.AddDbContext<DataBaseContext>(options => options.UseSqlServer(conn));
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFIAP.Domain.Interfaces.Repositories;
using TechChallengeFIAP.Domain.Interfaces.Services;
using TechChallengeFIAP.Domain.Services;
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

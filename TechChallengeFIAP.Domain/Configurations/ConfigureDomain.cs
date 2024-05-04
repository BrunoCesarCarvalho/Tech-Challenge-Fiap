using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TechChallengeFiap.Integrations.MercadoPagoFIAP.Interfaces;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Services;
using TechChallengeFIAP.Domain.Interfaces.Services;
using TechChallengeFIAP.Domain.Services;

namespace TechChallengeFIAP.Domain.Configurations
{
    public static class ConfigureDomain
    {
        public static void ConfigurationDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProdutoService, ProdutoService>();
            serviceCollection.AddScoped<IClienteService, ClienteService>();
            serviceCollection.AddScoped<IPedidoService, PedidoService>();

            serviceCollection.AddScoped<IMercadoPagoService, MercadoPagoService>();
        }
    }
}

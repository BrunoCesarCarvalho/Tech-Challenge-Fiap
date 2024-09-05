using Microsoft.Extensions.DependencyInjection;

using TechChallengeFiap.Integrations.MercadoPagoFIAP.Interfaces;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Services;
using TechChallengeFIAP.Domain.DomainEntities;
using TechChallengeFIAP.Domain.DomainEntities.Interfaces;
using TechChallengeFIAP.Domain.Entities;
using TechChallengeFIAP.Domain.InterfacesUserCases.Services;
using TechChallengeFIAP.Domain.Services;
using TechChallengeFIAP.Domain.ServicesUserCases;

namespace TechChallengeFIAP.Domain.Configurations
{
    public static class ConfigureDomain
    {
        public static void ConfigurationDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProdutoUserCase, ProdutoUserCase>();
            serviceCollection.AddScoped<IClienteUserCase, ClienteUserCase>();
            serviceCollection.AddScoped<IPedidoUserCase, PedidoUserCase>();

            serviceCollection.AddScoped<IPedidoDomain, DomainPedido>();
            serviceCollection.AddScoped<IClienteDomain, ClienteDomain>();
            serviceCollection.AddScoped<IPedidoProdutoDomain, PedidoProdutoDomain>();

            serviceCollection.AddScoped<IMercadoPagoService, MercadoPagoService>();
        }
    }
}

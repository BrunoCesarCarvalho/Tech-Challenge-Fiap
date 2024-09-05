using TechChallengeFIAP.Api.Mappings;
using TechChallengeFIAP.Core.AbstractServices;
using TechChallengeFIAP.Core.ConcretServices;

namespace TechChallengeFIAP.Api.Configurations
{
    public static class ConfiguraApi
    {
        public static void ConfigurationAutoMappings(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(PedidoProfile));
        }
    }
}

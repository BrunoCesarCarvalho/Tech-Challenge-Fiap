using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Tech_Challenge_Fiap.Core.AbstractServices;
using Tech_Challenge_Fiap.Core.ConcretServices;

namespace Tech_Challenge_Fiap.Core.Configurations
{
    public static class ConfiguraCore
    {
        public static void ConfigurationCore(this IServiceCollection serviceCollection)
        {           
            serviceCollection.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });
        }
    }
}

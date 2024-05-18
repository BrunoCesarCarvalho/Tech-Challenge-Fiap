using Microsoft.Extensions.Configuration;

namespace TechChallengeFiap.Integrations.MercadoPagoFIAP.Abstracts
{
    public abstract class MercadoPagoAbstract
    {
        //private readonly IConfiguration _configuration;
        public readonly string Url = null;
        public readonly string PublicKey = null;
        public readonly string AccessToken = null;
        protected MercadoPagoAbstract()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            // Constrói a configuração
            var _configuration = builder.Build();

            AccessToken = _configuration["Integracao:MercadoPago:AccessToken"];
            PublicKey = _configuration["Integracao:MercadoPago:PublicKey"];
            Url = _configuration["Integracao:MercadoPago:Url"];
        }
    }
}

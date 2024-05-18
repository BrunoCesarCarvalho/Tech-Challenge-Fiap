using TechChallengeFiap.Integrations.MercadoPagoFIAP.Models;

namespace TechChallengeFiap.Integrations.MercadoPagoFIAP.Interfaces
{
    public interface IMercadoPagoService
    {
        Task<string> CallQrCode(PayloadModel payloadModel);
    }
}

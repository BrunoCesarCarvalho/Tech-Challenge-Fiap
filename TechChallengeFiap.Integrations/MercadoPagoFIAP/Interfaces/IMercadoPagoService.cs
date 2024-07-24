using TechChallengeFiap.Integrations.MercadoPagoFIAP.Models;

namespace TechChallengeFiap.Integrations.MercadoPagoFIAP.Interfaces
{
    public interface IMercadoPagoService
    {
        Task<MercadoPagoQrCodeModel> CallQrCode(PayloadModel payloadModel);
    }
}

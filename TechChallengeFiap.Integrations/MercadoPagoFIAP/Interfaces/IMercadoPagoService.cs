using TechChallengeFiap.Integrations.MercadoPagoFIAP.Models;

namespace TechChallengeFiap.Integrations.MercadoPagoFIAP.Interfaces
{
    public interface IMercadoPagoService
    {
        Task<MercadoPagoQrCodeModel> GenerateQrCode(PayloadModel payloadModel);
    }
}

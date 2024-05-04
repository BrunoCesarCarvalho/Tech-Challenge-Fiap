using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Models;

namespace TechChallengeFiap.Integrations.MercadoPagoFIAP.Interfaces
{
    public interface IMercadoPagoService
    {
        Task<string> CallQrCode(PayloadModel payloadModel);
    }
}

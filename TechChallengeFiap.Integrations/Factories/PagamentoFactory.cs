using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFiap.Integrations.Abstracts;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Abstracts;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Services;
using TechChallengeFIAP.Enums;

namespace TechChallengeFiap.Integrations.Factories
{
    public class PagamentoFactory
    {
        public static PagamentoAbstract CreatePayment(EnumTipoGatewayPagamento enumTipoGatewayPagamento)
        {
            switch (enumTipoGatewayPagamento)
            {
                case EnumTipoGatewayPagamento.MercadoPago:
                    return new MercadoPagoService();
                default:
                    throw new ArgumentException("Method of payment not supported.");
            }
        }
    }
}

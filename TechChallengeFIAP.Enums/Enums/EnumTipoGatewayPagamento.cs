using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFiap.Core.Helpers;

namespace TechChallengeFIAP.Enums
{

    [TypeConverter(typeof(EnumTypeConverter<EnumTipoGatewayPagamento>))]
    public enum EnumTipoGatewayPagamento
    {
        MercadoPago = 1,
        PayPal = 2
    }
}

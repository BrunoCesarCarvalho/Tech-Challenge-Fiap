using System.ComponentModel;
using TechChallengeFiap.Core.Helpers;

namespace TechChallengeFIAP.Domain.Enums
{
    [TypeConverter(typeof(EnumTypeConverter<EnumStatusPagamento>))]
    public enum EnumStatusPagamento
    {
        Pendente = 1,
        Pago = 2
    }
}

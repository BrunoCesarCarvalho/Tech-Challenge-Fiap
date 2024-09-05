using System.ComponentModel;
using TechChallengeFiap.Core.Helpers;

namespace TechChallengeFIAP.Enums
{

    [TypeConverter(typeof(EnumTypeConverter<EnumPedidoStatusEtapa>))]
    public enum EnumPedidoStatusEtapa
    {
        Recebido = 1,
        EmPreparacao = 2,
        Pronto = 3,
        Finalizado = 4
    }
}

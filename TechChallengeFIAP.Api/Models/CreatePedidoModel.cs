using TechChallengeFIAP.Enums;

namespace TechChallengeFIAP.Models
{
    public class CreatePedidoModel
    {
        public CreateClienteModel? Cliente { get; set; }
        public List<CreatePedidoProdutosModel> ListPedidoProdutos { get; set; }
        public EnumTipoGatewayPagamento EnumTipoGatewayPagamento { get; set; }
    }
}

using TechChallengeFIAP.Enums;

namespace TechChallengeFIAP.DTOs
{
    public class CreatePedidoDTO
    {
        public CreateClienteDTO? Cliente { get; set; }
        public List<CreatePedidoProdutosDTO> ListPedidoProdutos { get; set; }

        public EnumTipoGatewayPagamento EnumTipoGatewayPagamento { get; set; }
    }
}

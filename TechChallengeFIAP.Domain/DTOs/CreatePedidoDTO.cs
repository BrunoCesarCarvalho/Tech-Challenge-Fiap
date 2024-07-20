namespace TechChallengeFIAP.Domain.DTOs
{
    public class CreatePedidoDTO
    {
        public CreateClienteDTO? Cliente { get; set; }
        public List<CreatePedidoProdutosDTO> ListPedidoProdutos { get; set; }
    }
}

namespace TechChallengeFIAP.Domain.DTOs
{
    public class CreatePedidoOnlyDTO
    {
        public int IdCliente { get; set; }
        public int IdStatusEtapa { get; set; }
        public int IdStatusPagamento { get; set; }
        public int IdPedidoProdutos { get; set; }
        public decimal ValorTotal { get; set; }
    }
}

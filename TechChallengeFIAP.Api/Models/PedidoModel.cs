namespace TechChallengeFIAP.Models
{
    public class PedidoModel
    {
        public int? PedidoId { get; set; }
        public string? PedidoIdMercadoPago { get; set; }
        public DateTime? Data { get; set; }
        public decimal? ValorTotal { get; set; }

        public string QrData {get; set; }
        public ClienteModel Cliente { get; set; }
        public PedidoStatusEtapaModel StatusEtapa { get; set; }
        public StatusPagamentoModel StatusPagamento { get; set; }
        public ICollection<PedidoProdutosModel> PedidoProdutos { get; set; }
    }
}

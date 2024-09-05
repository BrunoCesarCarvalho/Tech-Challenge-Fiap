namespace TechChallengeFIAP.Models
{
    public class CreatePedidoProdutosOnlyModel
    {
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}

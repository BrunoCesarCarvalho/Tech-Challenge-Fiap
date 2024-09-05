namespace TechChallengeFIAP.DTOs
{
    public class PedidoProdutosDTO
    {
        public int Id { get; set; }       
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }

        public ProdutoDTO Produto { get; set; }
    }
}

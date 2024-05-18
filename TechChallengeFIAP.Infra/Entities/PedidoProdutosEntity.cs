using System.ComponentModel.DataAnnotations;

namespace TechChallengeFIAP.Infra.Entities
{
    public class PedidoProdutosEntity
    {
        [Key]
        public int Id { get; set;}       
        public int IdPedido { get; set;}
        public int IdProduto { get; set;}
        public int Quantidade { get; set;}

        public PedidoEntity Pedido { get; set;}
        public ProdutoEntity Produto { get; set;}
    }
}

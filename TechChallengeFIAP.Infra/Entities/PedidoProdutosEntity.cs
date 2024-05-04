using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

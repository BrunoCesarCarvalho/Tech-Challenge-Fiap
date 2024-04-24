using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeFIAP.Domain.DTOs
{
    public class CreateProdutoDTO
    {
        public int IdCategoriaProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }      
        public List<CreateProdutoImagensDTO>? ProdutoImagens { get; set; }
    }
}

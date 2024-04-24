using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeFIAP.Infra.Entities
{
    public class ProdutoImagensEntity
    {
        [Key]
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public byte[] Foto { get; set;}

        public virtual ProdutoEntity Produto { get; set; }
    }
}

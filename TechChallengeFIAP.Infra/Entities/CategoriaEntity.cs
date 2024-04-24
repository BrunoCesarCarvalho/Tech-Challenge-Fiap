using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeFIAP.Infra.Entities
{
    public class CategoriaEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<ProdutoEntity> Produtos { get; set; }
    }
}

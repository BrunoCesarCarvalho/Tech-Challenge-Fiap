using System.ComponentModel.DataAnnotations;

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

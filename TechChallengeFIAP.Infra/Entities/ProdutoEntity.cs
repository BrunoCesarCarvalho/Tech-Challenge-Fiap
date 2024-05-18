using System.ComponentModel.DataAnnotations;

namespace TechChallengeFIAP.Infra.Entities
{
    public class ProdutoEntity
    {
        [Key]
        public int Id { get; set; }
        public int IdCategoriaProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor {  get; set; }

        public virtual CategoriaEntity Categoria { get; set; }
        public virtual ICollection<ProdutoImagensEntity> Imagens { get; set; }
    }
}

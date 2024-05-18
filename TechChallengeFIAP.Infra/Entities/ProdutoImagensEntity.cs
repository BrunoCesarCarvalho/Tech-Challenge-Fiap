using System.ComponentModel.DataAnnotations;

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

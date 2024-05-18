using System.ComponentModel.DataAnnotations;

namespace TechChallengeFIAP.Domain.DTOs
{
    public class EditProdutoImagensDTO
    {
        [Key]
        public int Id { get; set; }
        public int IdProduto {  get; set; }
        public byte[] Foto { get; set; }
    }
}

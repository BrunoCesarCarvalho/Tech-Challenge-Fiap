using System.ComponentModel.DataAnnotations;

namespace TechChallengeFIAP.Domain.DTOs
{
    public class CategoriaDTO
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}

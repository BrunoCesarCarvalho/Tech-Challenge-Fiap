using System.ComponentModel.DataAnnotations;

namespace TechChallengeFIAP.DTOs
{
    public class CategoriaDTO
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}

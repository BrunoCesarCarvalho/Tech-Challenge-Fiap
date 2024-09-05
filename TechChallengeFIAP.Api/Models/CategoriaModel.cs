using System.ComponentModel.DataAnnotations;

namespace TechChallengeFIAP.Models
{
    public class CategoriaModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}

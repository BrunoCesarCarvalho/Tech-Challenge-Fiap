using System.ComponentModel.DataAnnotations;

namespace TechChallengeFIAP.Infra.Entities
{
    public class ClienteEntity
    {
        [Key]
        public int Id { get; set; } 
        public string Cpf {  get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}

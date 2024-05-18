using TechChallengeFIAP.Domain.Validations;

namespace TechChallengeFIAP.Domain.DTOs
{
    public class ClienteCadastroDTO
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        [BirthDate]
        public string DataNascimento { get; set; }
    }
}

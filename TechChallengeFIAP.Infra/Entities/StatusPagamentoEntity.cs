using System.ComponentModel.DataAnnotations;

namespace TechChallengeFIAP.Infra.Entities
{
    public class StatusPagamentoEntity
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TechChallengeFIAP.Infra.Entities
{
    public class PedidoStatusEtapaEntity
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}

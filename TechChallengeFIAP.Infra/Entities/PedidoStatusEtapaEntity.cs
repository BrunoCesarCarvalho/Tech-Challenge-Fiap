using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeFIAP.Infra.Entities
{
    public class PedidoStatusEtapaEntity
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}

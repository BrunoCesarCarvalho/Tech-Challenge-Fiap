using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeFIAP.Infra.Entities
{
    public class TipoGatewayPagamentoEntity
    {
        [Key]
        public int Id { get; set; }

        public int IdTipo { get; set; }
        public string Descricao { get; set; }
    }
}

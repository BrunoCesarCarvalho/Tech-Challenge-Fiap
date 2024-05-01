using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeFIAP.Infra.Entities
{
    public class ClienteEntity
    {
        [Key]
        public int Id { get; set; } 
        public string Cpf {  get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}

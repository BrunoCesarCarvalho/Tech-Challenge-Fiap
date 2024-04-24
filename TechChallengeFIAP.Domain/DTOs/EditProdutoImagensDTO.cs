using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeFIAP.Domain.DTOs
{
    public class EditProdutoImagensDTO
    {
        [Key]
        public int Id { get; set; }
        public int IdProduto {  get; set; }
        public byte[] Foto { get; set; }
    }
}

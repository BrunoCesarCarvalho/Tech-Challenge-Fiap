using System.ComponentModel.DataAnnotations;

namespace TechChallengeFIAP.Models
{
    public class EditProdutoImagensModel
    {        
        public int? Id { get; set; }
        public int? IdProduto { get; set; }
        public byte[]? Foto { get; set; }
    }
}

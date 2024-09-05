using System.ComponentModel.DataAnnotations;

namespace TechChallengeFIAP.DTOs
{
    public class EditProdutoImagensDTO
    {        
        public int? Id { get; set; }
        public int? IdProduto { get; set; }
        public byte[]? Foto { get; set; }
    }
}

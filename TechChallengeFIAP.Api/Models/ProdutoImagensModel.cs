namespace TechChallengeFIAP.Models
{
    public class ProdutoImagensModel
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public byte[] Foto { get; set; }
    }
}

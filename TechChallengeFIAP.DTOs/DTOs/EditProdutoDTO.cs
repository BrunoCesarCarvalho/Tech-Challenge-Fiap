namespace TechChallengeFIAP.DTOs
{
    public class EditProdutoDTO
    {
        public int Id { get; set; } 
        public int IdCategoriaProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public List<EditProdutoImagensDTO>? EditProdutoImagensDTO { get; set; }
    }
}

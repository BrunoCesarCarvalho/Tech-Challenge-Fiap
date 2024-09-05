namespace TechChallengeFIAP.Models
{
    public class EditProdutoModel
    {
        public int Id { get; set; } 
        public int IdCategoriaProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public List<EditProdutoImagensModel>? EditProdutoImagensDTO { get; set; }
    }
}

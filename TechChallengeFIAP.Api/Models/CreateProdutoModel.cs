namespace TechChallengeFIAP.Models
{
    public class CreateProdutoModel
    {
        public int IdCategoriaProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }      
        public List<CreateProdutoImagensModel>? ProdutoImagens { get; set; }
    }
}

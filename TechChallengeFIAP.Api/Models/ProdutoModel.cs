namespace TechChallengeFIAP.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public int IdCategoriaProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public CategoriaModel CategoriaModel { get; set; }

        public List<ProdutoImagensModel> ProdutoImagensModel { get; set; }
    }
}

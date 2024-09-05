namespace TechChallengeFIAP.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public int IdCategoriaProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public CategoriaDTO CategoriaDTO { get; set; }

        public List<ProdutoImagensDTO> ProdutoImagensDTO { get; set; }
    }
}

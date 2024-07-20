namespace TechChallengeFIAP.Core.Paginetes
{
    public class PaginationFilter
    {
        public int PedidoId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationFilter()
        {
            this.PedidoId = 0;
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public PaginationFilter(int pageNumber, int pageSize, int pedidoId)
        {
            this.PedidoId = pedidoId < 1 ? 0 : pedidoId;
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}

using Tech_Challenge_Fiap.Core.Paginetes;

namespace Tech_Challenge_Fiap.Core.AbstractServices
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}

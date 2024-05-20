using TechChallengeFIAP.Core.Paginetes;

namespace TechChallengeFIAP.Core.AbstractServices
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}

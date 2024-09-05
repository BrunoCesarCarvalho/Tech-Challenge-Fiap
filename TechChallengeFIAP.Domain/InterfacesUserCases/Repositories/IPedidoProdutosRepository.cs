using TechChallengeFIAP.DTOs;

namespace TechChallengeFIAP.Domain.InterfacesUserCases.Repositories
{
    public interface IPedidoProdutosRepository
    {
        Task CreateAsync(List<CreatePedidoProdutosOnlyDTO> listCreatePedidoProdutosDTO);
    }
}

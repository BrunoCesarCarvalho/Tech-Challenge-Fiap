using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeFIAP.Domain.DTOs
{
    public class CreatePedidoDTO
    {
        public CreateClienteDTO Cliente { get; set; }
        public List<CreatePedidoProdutosDTO> ListPedidoProdutos { get; set; }
    }
}

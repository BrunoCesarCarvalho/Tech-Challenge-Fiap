using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeFIAP.Domain.DTOs
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }

        public ClienteDTO Cliente { get; set; }
        public PedidoStatusEtapaDTO StatusEtapa { get; set; }
        public StatusPagamentoDTO StatusPagamento { get; set; }
        public ICollection<PedidoProdutosDTO> PedidoProdutos { get; set; }
    }
}

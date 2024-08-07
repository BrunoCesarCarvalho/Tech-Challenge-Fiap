﻿using System.ComponentModel.DataAnnotations;

namespace TechChallengeFIAP.Infra.Entities
{
    public class PedidoEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int IdCliente { get; set; }
        public int IdStatusEtapa {  get; set; }
        public int IdStatusPagamento { get; set; }
        public decimal ValorTotal {  get; set; }
        public string? QrData { get; set; }
        public string? IdPedidoMercadoPago { get; set; }

        public ClienteEntity Cliente { get; set; }
        public PedidoStatusEtapaEntity StatusEtapa { get; set; }
        public StatusPagamentoEntity StatusPagamento { get; set; }
        public ICollection<PedidoProdutosEntity> PedidoProdutos { get; set; }

    }
}

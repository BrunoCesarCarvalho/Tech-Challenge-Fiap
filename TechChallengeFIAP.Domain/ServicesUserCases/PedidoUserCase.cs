using QRCoder;
using System.Drawing;
using TechChallengeFIAP.Core.Paginetes;
using TechChallengeFIAP.Core.Responses;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Interfaces;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Models;
using TechChallengeFIAP.DTOs;
using TechChallengeFIAP.Domain.InterfacesUserCases.Repositories;
using TechChallengeFIAP.Domain.InterfacesUserCases.Services;
using TechChallengeFIAP.Domain.Entities;
using TechChallengeFIAP.Domain.DomainEntities.Interfaces;
using TechChallengeFiap.Integrations.Abstracts;
using TechChallengeFiap.Integrations.Factories;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Abstracts;
using TechChallengeFIAP.Enums;


namespace TechChallengeFIAP.Domain.Services
{
    public class PedidoUserCase : IPedidoUserCase
    {

        private readonly IMercadoPagoService _mercadoPagoService;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoProdutosRepository _pedidoProdutosRepository;
        private readonly IClienteRepository _clienteRepository;


        private readonly IPedidoDomain _pedidoDomain;
        private readonly IClienteDomain _clienteDomain;
        private readonly IPedidoProdutoDomain _pedidoProdutoDomain;


        public PedidoUserCase(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository, IPedidoProdutosRepository pedidoProdutosRepository, IClienteRepository clienteRepository, IMercadoPagoService mercadoPagoService, IPedidoDomain domainPedido, IClienteDomain clienteDomain, IPedidoProdutoDomain pedidoProdutoDomain)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _pedidoProdutosRepository = pedidoProdutosRepository;
            _clienteRepository = clienteRepository;
            _mercadoPagoService = mercadoPagoService;
            _pedidoDomain = domainPedido;
            _clienteDomain = clienteDomain;
            _pedidoProdutoDomain = pedidoProdutoDomain;
        }

        public async Task<PagedResponse<List<PedidoDTO>>> GetAllAsync(PaginationFilter filter)
        {
            return await _pedidoDomain.GetAllAsync(filter);
        }

        public async Task<int> CreatePedidoAsync(CreatePedidoDTO createPedidoDTO)
        {
            int idClienteAvulso = 0;
            var clienteDTO = await _clienteDomain.GetByCpfAsync(createPedidoDTO?.Cliente?.Cpf);

            if (clienteDTO is null)
            {
                idClienteAvulso = await _clienteDomain.CreateAsync(new ClienteCadastroDTO()
                {
                    Cpf = "00000000000",
                    Email = "00000000000",
                    Nome = "Avulso",
                    DataNascimento = DateTime.Now.ToString("yyyy-MM-dd")
                });
            }

            decimal totalAmount = await _pedidoDomain.GetTotalAmount(createPedidoDTO.ListPedidoProdutos);

            var createPedidoOnlyDTO = new CreatePedidoOnlyDTO();
            createPedidoOnlyDTO.ValorTotal = totalAmount;
            createPedidoOnlyDTO.IdCliente = idClienteAvulso > 0 ? idClienteAvulso : clienteDTO.Id;
            createPedidoOnlyDTO.IdStatusEtapa = (int)EnumPedidoStatusEtapa.Recebido;
            createPedidoOnlyDTO.IdStatusPagamento = (int)EnumStatusPagamento.Pendente;
            createPedidoOnlyDTO.EnumTipoGatewayPagamento = createPedidoDTO.EnumTipoGatewayPagamento;

            var idPedido = await _pedidoDomain.CreatePedidoAsync(createPedidoOnlyDTO);

            var listCreatePedidoProdutosOnlyDTO = MapObjectCreatePedidoProdutos(createPedidoDTO, idPedido);

            await _pedidoProdutoDomain.CreateAsync(listCreatePedidoProdutosOnlyDTO);

            //hardCode para fins acadêmicos, poderia vir PayPall, mas não entraria no if abaixo
            var pagamentoAbstract = PagamentoFactory.CreatePayment(createPedidoDTO.EnumTipoGatewayPagamento);

            if (pagamentoAbstract != null && pagamentoAbstract is MercadoPagoAbstract mercadoPago)
            {
                var pedidoMercadoPago = await _pedidoDomain.GetByIdAsync(idPedido);
                var payloadModel = MapObjectMercadoPago(idClienteAvulso, clienteDTO, totalAmount, idPedido, pedidoMercadoPago);
                var mercadoPagoQrCodeModel = await mercadoPago.GenerateQrCode(payloadModel);
                await _pedidoDomain.SaveQrCodeAsync(mercadoPagoQrCodeModel, idPedido);
            }

            return idPedido;
        }

        private static List<CreatePedidoProdutosOnlyDTO> MapObjectCreatePedidoProdutos(CreatePedidoDTO createPedidoDTO, int idPedido)
        {
            var listCreatePedidoProdutosOnlyDTO = new List<CreatePedidoProdutosOnlyDTO>();

            foreach (var pedidosProdutos in createPedidoDTO.ListPedidoProdutos)
            {
                var createPedidoProdutosOnlyDTO = new CreatePedidoProdutosOnlyDTO()
                {
                    IdPedido = idPedido,
                    IdProduto = pedidosProdutos.IdProduto,
                    Quantidade = pedidosProdutos.Quantidade,

                };

                listCreatePedidoProdutosOnlyDTO.Add(createPedidoProdutosOnlyDTO);
            }

            return listCreatePedidoProdutosOnlyDTO;
        }

        private static PayloadModel MapObjectMercadoPago(int idClienteAvulso, ClienteDTO? clienteDTO, decimal totalAmount, int idPedido, PedidoDTO pedidoMercadoPago)
        {
            var payloadModel = new PayloadModel();
            payloadModel.external_reference = idPedido.ToString();
            payloadModel.total_amount = totalAmount;
            payloadModel.title = idClienteAvulso > 0 ? idClienteAvulso.ToString() : clienteDTO.Id.ToString();
            payloadModel.description = idClienteAvulso > 0 ? idClienteAvulso.ToString() : clienteDTO.Id.ToString();
            payloadModel.notification_url = $"https://hookb.in/9X9WQQmQ3puyw80KPddB";

            payloadModel.items = new List<ItemModel>();

            foreach (var itens in pedidoMercadoPago.PedidoProdutos)
            {

                var item = new ItemModel()
                {
                    sku_number = "KS955RUR",
                    category = "LIBRERIA",
                    title = "Lapicera",
                    description = "Lapicera verde",
                    quantity = itens.Quantidade,
                    unit_measure = "unit",
                    unit_price = itens.Produto.Valor,
                    total_amount = itens.Quantidade * itens.Produto.Valor
                };

                payloadModel.items.Add(item);
            }

            return payloadModel;
        }

        public async Task<byte[]> GetQrCodeAsync(int IdPedido)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(IdPedido);
            if (pedido != null)
            {
                if (pedido.StatusPagamento.Id == (int)EnumStatusPagamento.Pago)
                    throw new Exception("Pedido já foi pago");
                else
                    return GenerateByteArray(pedido.QrData);
            }
            throw new Exception("Pedido not found.");
        }

        private byte[] GenerateByteArray(string url)
        {
            var image = GenerateImage(url);
            return ImageToByte(image);
        }

        private Bitmap GenerateImage(string url)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(10);
            return qrCodeImage;
        }
        private byte[] ImageToByte(Image img)
        {
            using var stream = new MemoryStream();
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }

        public async Task ChangeStatusAsync(int idPedido, int idStatus)
        {
            switch (idStatus)
            {
                case (int)EnumPedidoStatusEtapa.Recebido:
                case (int)EnumPedidoStatusEtapa.EmPreparacao:
                case (int)EnumPedidoStatusEtapa.Pronto:
                case (int)EnumPedidoStatusEtapa.Finalizado:
                    await _pedidoRepository.ChangeStatusAsync(idPedido, idStatus);
                    break;
                default: throw new Exception("There is not exist option.");

            }
        }

        public async Task ConfirmPaymentAsync(int idPedido)
        {
            _ = await _pedidoRepository.GetByIdAsync(idPedido) ?? throw new Exception("Pedido not found.");
            await _pedidoRepository.ConfirmPaymentAsync(idPedido);
        }

        public async Task ConfirmePaymentMercadoPagoAsync(string IdPedidoMercadoPago)
        {
            _ = await _pedidoRepository.GetMercadoPagoByIdAsync(IdPedidoMercadoPago) ?? throw new Exception("Pedido not found.");
            await _pedidoRepository.ConfirmePaymentMercadoPagoAsync(IdPedidoMercadoPago);
        }

        public async Task<PagedResponse<List<PedidoDTO>>> PedidosActive(PaginationFilter filter)
        {
            return await _pedidoRepository.PedidosActive(filter);
        }
    }
}

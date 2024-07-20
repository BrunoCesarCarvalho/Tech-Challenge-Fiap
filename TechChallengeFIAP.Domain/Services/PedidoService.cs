using QRCoder;
using System.Drawing;
using TechChallengeFIAP.Core.Paginetes;
using TechChallengeFIAP.Core.Responses;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Interfaces;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Models;
using TechChallengeFIAP.Domain.DTOs;
using TechChallengeFIAP.Domain.Enums;
using TechChallengeFIAP.Domain.Interfaces.Repositories;
using TechChallengeFIAP.Domain.Interfaces.Services;


namespace TechChallengeFIAP.Domain.Services
{
    public class PedidoService : IPedidoService
    {

        private readonly IMercadoPagoService _mercadoPagoService;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoProdutosRepository _pedidoProdutosRepository;
        private readonly IClienteRepository _clienteRepository;

        public PedidoService(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository, IPedidoProdutosRepository pedidoProdutosRepository, IClienteRepository clienteRepository, IMercadoPagoService mercadoPagoService)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _pedidoProdutosRepository = pedidoProdutosRepository;
            _clienteRepository = clienteRepository;
            _mercadoPagoService = mercadoPagoService;
        }

        public async Task<PagedResponse<List<PedidoDTO>>> GetAllAsync(PaginationFilter filter)
        {
            return await _pedidoRepository.GetAllAsync(filter);
        }

        public async Task<int> CreatePedidoAsync(CreatePedidoDTO createPedidoDTO)
        {
            int idClienteAvulso = 0;
            var clienteDTO = await _clienteRepository.GetByCpfAsync(createPedidoDTO?.Cliente?.Cpf);

            if (clienteDTO is null)
            {
                idClienteAvulso = await _clienteRepository.CreateAsync(new ClienteCadastroDTO()
                {
                    Cpf = "00000000000",
                    Email = "00000000000",
                    Nome = "Avulso",
                    DataNascimento = DateTime.Now.ToString("yyyy-MM-dd")
                });
            }

            var createPedidoOnlyDTO = new CreatePedidoOnlyDTO();
            decimal totalAmount = 0;
            foreach (var produto in createPedidoDTO.ListPedidoProdutos)
            {
                var valueProduct = await _produtoRepository.GetByIdAsync(produto.IdProduto);

                totalAmount += valueProduct.Valor * produto.Quantidade;
            }

            createPedidoOnlyDTO.ValorTotal = totalAmount;
            createPedidoOnlyDTO.IdCliente = idClienteAvulso > 0 ? idClienteAvulso : clienteDTO.Id;
            createPedidoOnlyDTO.IdStatusEtapa = (int)EnumPedidoStatusEtapa.Recebido;
            createPedidoOnlyDTO.IdStatusPagamento = (int)EnumStatusPagamento.Pendente;

            var idPedido = await _pedidoRepository.CreatePedidoAsync(createPedidoOnlyDTO);

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

            await _pedidoProdutosRepository.CreateAsync(listCreatePedidoProdutosOnlyDTO);

            var pedidoMercadoPago = await _pedidoRepository.GetPedidoMercadoPago(idPedido);

            var payloadModel = new PayloadModel();
            payloadModel.external_reference = idPedido.ToString();
            payloadModel.total_amount = totalAmount;
            payloadModel.title = idClienteAvulso > 0 ? idClienteAvulso.ToString() : clienteDTO.Id.ToString();
            payloadModel.description = idClienteAvulso > 0 ? idClienteAvulso.ToString() : clienteDTO.Id.ToString();
            payloadModel.notification_url = "https://hookb.in/9X9WQQmQ3puyw80KPddB";

            payloadModel.items = new List<ItemModel>();

            foreach (var itens in pedidoMercadoPago)
            {

                var item = new ItemModel()
                {
                    sku_number = "KS955RUR",
                    category = "LIBRERIA",
                    title = "Lapicera",
                    description = "Lapicera verde",
                    quantity = itens.Quantidade,
                    unit_measure = "unit",
                    unit_price = itens.Valor,
                    total_amount = itens.Quantidade * itens.Valor
                };

                payloadModel.items.Add(item);
            }

            var qrData = await _mercadoPagoService.CallQrCode(payloadModel);
            await _pedidoRepository.SaveQrDataAsync(qrData, idPedido);

            return idPedido;
        }

        public async Task<byte[]> GetQrCodeAsync(int IdPedido)
        {
            var pedidoJaPago = await _pedidoRepository.GetByIdAsync(IdPedido);
            if (pedidoJaPago != null && pedidoJaPago.StatusPagamento.Id == (int)EnumStatusPagamento.Pago)
                throw new Exception("Pedido já foi pago");

            var pedido = await _pedidoRepository.GetByIdAsync(IdPedido);
            return GenerateByteArray(pedido.QrData);
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
            await _pedidoRepository.ConfirmPaymentAsync(idPedido);
        }

        public async Task<PagedResponse<List<PedidoDTO>>> PedidosActive(PaginationFilter filter)
        {
            return await _pedidoRepository.PedidosActive(filter);
        }
    }
}

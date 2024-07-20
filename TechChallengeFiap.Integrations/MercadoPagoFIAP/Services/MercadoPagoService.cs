using Newtonsoft.Json;
using System.Text;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Abstracts;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Interfaces;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Models;



namespace TechChallengeFiap.Integrations.MercadoPagoFIAP.Services
{
    public class MercadoPagoService : MercadoPagoAbstract, IMercadoPagoService
    {
        public MercadoPagoService() : base()
        {

        }

        public async Task<string> CallQrCode(PayloadModel pedidoMercadoPagoDTO)
        {

            var payload = JsonConvert.SerializeObject(pedidoMercadoPagoDTO, Formatting.Indented);


            using (HttpClient client = new HttpClient())
            {
                // URL da API
                //string url = "https://api.mercadopago.com/users/1795994429/stores";

                string url = "https://api.mercadopago.com/instore/orders/qr/seller/collectors/1795994429/pos/Caixa_Vendedor/qrs";

                // Cabeçalhos da requisição
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");

                // Corpo da requisição
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                // Realiza a requisição POST
                HttpResponseMessage response = await client.PostAsync(url, content);

                // Verifica se a requisição foi bem sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Exibe a resposta
                    string responseBody = await response.Content.ReadAsStringAsync();

                    MercadoPagoQrCodeModel mercadoPagoQrCode = JsonConvert.DeserializeObject<MercadoPagoQrCodeModel>(responseBody);
                    return mercadoPagoQrCode.qr_data;
                }
                string responseBodyBadRequest = await response.Content.ReadAsStringAsync();
                throw new Exception("Exception: " + responseBodyBadRequest);
            }
        }
    }
}

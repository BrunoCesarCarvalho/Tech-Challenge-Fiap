using Newtonsoft.Json;
using System.Text;
using TechChallengeFiap.Integrations.Abstracts;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Abstracts;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Interfaces;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Models;



namespace TechChallengeFiap.Integrations.MercadoPagoFIAP.Services
{
    public class MercadoPagoService : MercadoPagoAbstract, IMercadoPagoService
    {
        public MercadoPagoService() : base()
        {}       
        public async override Task<MercadoPagoQrCodeModel> GenerateQrCode(PayloadModel pedidoMercadoPagoDTO)
        {
            var payload = JsonConvert.SerializeObject(pedidoMercadoPagoDTO, Formatting.Indented);

            using (HttpClient client = new HttpClient())
            {               
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(Url, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var mercadoPagoQrCode = JsonConvert.DeserializeObject<MercadoPagoQrCodeModel>(responseBody);
                    return mercadoPagoQrCode;
                }
                string responseBodyBadRequest = await response.Content.ReadAsStringAsync();
                throw new Exception("Exception: " + responseBodyBadRequest);
            }
        }      
    }
}

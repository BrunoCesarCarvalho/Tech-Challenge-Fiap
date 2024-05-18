// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Text;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Models;

Console.WriteLine("Hello, World!");

// Dados do payload em formato JSON
string payload = "";

var itemModel = new ItemModel();
itemModel.title = "Lapicera";
itemModel.sku_number = "KS955RUR";
itemModel.category = "LIBRERIA";
itemModel.title = "Lapicera";
itemModel.description = "Lapicera verde";
itemModel.quantity = 5;
itemModel.unit_measure = "unit";
itemModel.unit_price = 9;
itemModel.total_amount = 45;

var payloadModel = new PayloadModel();
payloadModel.items = new List<ItemModel>();
payloadModel.items.Add(itemModel);
payloadModel.external_reference = "order-id-1234";
payloadModel.total_amount = 45;
payloadModel.title = "Compra en Librería";
payloadModel.description = "Compra + Retiro";
payloadModel.notification_url = "https://hookb.in/9X9WQQmQ3puyw80KPddB";

payload = JsonConvert.SerializeObject(payloadModel, Formatting.Indented);



// Configuração do cliente HTTP
using (HttpClient client = new HttpClient())
{
    // URL da API
    //string url = "https://api.mercadopago.com/users/157873729/stores";

    string url = "https://api.mercadopago.com/instore/orders/qr/seller/collectors/157873729/pos/LojaFIAP1Caiax1/qrs";

    // Cabeçalhos da requisição
    client.DefaultRequestHeaders.Add("Authorization", "Bearer TEST-2511458319386961-050322-2740fa4358bfc214f2be301bc2f8bf44-157873729");
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

        MercadoPagoQrCode mercadoPagoQrCode = JsonConvert.DeserializeObject<MercadoPagoQrCode>(responseBody);
        Console.WriteLine("Resposta da API:");
        Console.WriteLine(responseBody);
    }
    else
    {
        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Resposta da API:");
        Console.WriteLine(responseBody);
    }

    Console.WriteLine("Hello, World!");
}

public class MercadoPagoQrCode
{
    public string in_store_order_id { get; set; }
    public string qr_data { get; set; }
}

public class Item
{
    public string sku_number { get; set; }
    public string category { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public int quantity { get; set; }
    public string unit_measure { get; set; }
    public int unit_price { get; set; }
    public int total_amount { get; set; }
}

public class RootObject
{
    public string external_reference { get; set; }
    public int total_amount { get; set; }
    public List<Item> items { get; set; } = new List<Item>();
    public string title { get; set; }
    public string description { get; set; }
    public string notification_url { get; set; }
}



﻿namespace TechChallengeFiap.Integrations.MercadoPagoFIAP.Models
{
    public class ItemModel
    {
        public string sku_number { get; set; }
        public string category { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public string unit_measure { get; set; }
        public decimal unit_price { get; set; }
        public decimal total_amount { get; set; }
    }
}

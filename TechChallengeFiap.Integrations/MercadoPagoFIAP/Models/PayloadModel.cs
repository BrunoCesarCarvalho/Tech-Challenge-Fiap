using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeFiap.Integrations.MercadoPagoFIAP.Models
{
    public class PayloadModel
    {
        public string external_reference { get; set; }
        public decimal total_amount { get; set; }
        public List<ItemModel> items { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string notification_url { get; set; }
    }
}

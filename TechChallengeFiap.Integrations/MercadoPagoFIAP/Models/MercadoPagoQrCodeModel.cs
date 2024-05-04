using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeFiap.Integrations.MercadoPagoFIAP.Models
{
    public class MercadoPagoQrCodeModel
    {
        public string in_store_order_id { get; set; }
        public string qr_data { get; set; }
    }
}

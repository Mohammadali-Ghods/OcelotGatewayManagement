using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalApi.ConfigurationModel
{
    public class ExretnalApiModel
    {
        public string StoreMicroserviceUrl { get; set; }
        public string ShippingMicroserviceUrl { get; set; }
        public string CustomerMicroserviceUrl { get; set; }
        public string PaymentMicroserviceUrl { get; set; }
    }
}

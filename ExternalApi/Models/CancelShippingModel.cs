using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalApi.Models
{
    public class CancelShippingModel
    {
        public string OrderID { get; set; }
        public string CancelReason { get; set; }
    }
}

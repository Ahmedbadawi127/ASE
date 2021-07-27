using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Shared.Dto
{
    public class DeliveryManStatesPricesDto
    {
        public LookupDto State { get; set; }
        public double DeliveryPrice { get; set; }

    }
}

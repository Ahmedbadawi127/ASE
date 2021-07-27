using Shipping.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Domain.Entities
{
    public class State : AuditableEntity
    {
        public State()
        {
            DeliveryMenStatesPrices = new List<DeliveryManStatesPrices>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DeliveryManStatesPrices> DeliveryMenStatesPrices { get; set; }

    }
}

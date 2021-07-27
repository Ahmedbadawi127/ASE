using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Domain.Entities
{
    public class DeliveryManStatesPrices
    {
        public int Id { get; set; }
        public double DeliveryPrice { get; set; }
        public int DeliveryManId { get; set; }
        public DeliveryMan DeliveryMan { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
    }
}

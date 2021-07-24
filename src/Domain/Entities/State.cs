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
            DeliveryMenStates = new List<DeliveryManState>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DeliveryManState> DeliveryMenStates { get; set; }

    }
}

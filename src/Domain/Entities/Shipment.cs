using Shipping.Domain.Common;
using Shipping.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Domain.Entities
{
    public class Shipment : AuditableEntity
    {
        public Shipment()
        {

	    }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public int ReceiverStateId { get; set; }
        public string ReceiverStateName { get; set; }
        public int ReceiverCityId { get; set; }
        public string ReceiverCityName { get; set; }
        public string Notes { get; set; }
        public string Address { get; set; }
        public int CashToBeCollected { get; set; }
        public ShipmentStatus Status { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        //public int DeliveryManId { get; set; }
        public DeliveryMan DeliveryMan { get; set; }

        public ApprovedShipment ApprovedShipment { get; set; }



    }
}
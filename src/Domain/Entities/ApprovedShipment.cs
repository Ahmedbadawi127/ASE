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
    public class ApprovedShipment : AuditableEntity
    {
        public ApprovedShipment()
        {

	    }

        [Key]
        public int Id { get; set; }
        public string ApprovedNotes { get; set; }
        public int DeliveryManId { get; set; }
        public string DeliveryManName { get; set; }
        public int ShipmentRef { get; set; }
        public Shipment Shipment { get; set; }
    }
}
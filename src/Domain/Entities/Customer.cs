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
    public partial class Customer : AuditableEntity
    {
        public Customer()
        {

	    }

        [Key]
        public int Id { get; set; }
        //[Required]
        //public int UserId { get; set; }
        [Required]
        [MaxLength(128)]
        public Guid SId { get; set; }
        [Required]
        [MaxLength(120)]
        public string NameAr { get; set; }
        [Required]
        [MaxLength(120)]
        public string NameEn { get; set; }
        public int Age { get; set; }
        public int GenderId { get; set; }
        [MaxLength(25)]
        public string GenderName { get; set; }

        [MaxLength(25)]
        public string Phone { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        public int StateId { get; set; }
        [MaxLength(25)]
         public string StateName { get; set; }
        public int CityId { get; set; }
        [MaxLength(25)]
        public string CityName { get; set; }
        //public User User { get; set; }

        public List<Shipment> Shipments { get; set; }


    }
}
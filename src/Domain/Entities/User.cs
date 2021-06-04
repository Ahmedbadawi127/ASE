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
    public partial class User : AuditableEntity
    {
        public User()
        {

            //Customers = new  List<Customer>();

	    }

        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public Guid SId { get; set; }
        [Required]
        [MaxLength(120)]
        public string NameAr { get; set; }
        [Required]
        [MaxLength(120)]
        public string NameEn { get; set; }
        [Required]
        public int UserTypeId { get; set; }





        //public List<Customer> Customers  {get; set;}


    }
}
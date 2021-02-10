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

//DesignatationCutDecisionRequests = new  List<DesignatationCutDecisionRequest>();

	    }

        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string SId { get; set; }
        [Required]
        [MaxLength(120)]
        public string NameAr { get; set; }
        [Required]
        [MaxLength(120)]
        public string NameEn { get; set; }
        [Required]
        public int UserTypeId { get; set; }
        [Required]
        [MaxLength(25)]
        public string TypeName { get; set; }
        [MaxLength(25)]
        public string Phone { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        public int StateId { get; set; }
        [MaxLength(25)]
         public string StateName { get; set; }
        public int RegionId { get; set; }
        [MaxLength(25)]
        public string RegionName { get; set; }



        //public List<DesignatationCutDecisionRequest> DesignatationCutDecisionRequests  {get; set;}


    }
}
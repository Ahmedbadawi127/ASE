using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping.Shared.Dto
{
    public class CustomersDto
    {
        public int Id { get; set; }
        public Guid SId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int Age { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public bool? Active { get; set; }
    }
}

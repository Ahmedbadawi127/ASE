using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping.Shared.Dto
{
    public class LookupWithCategDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public int CategoryId { get; set; }
    }
}

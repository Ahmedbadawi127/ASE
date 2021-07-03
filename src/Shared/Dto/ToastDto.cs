using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Shared.Dto
{
    public class ToastDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsVisible { get; set; }
    }
}

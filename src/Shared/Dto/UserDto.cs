using System;
using System.Collections.Generic;
using System.Text;

namespace Shipping.Shared.Dto
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Name { get; set; }
    }


    public class UserSCDto
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}

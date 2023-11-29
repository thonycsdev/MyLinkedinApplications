using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class UserRequest
    {
        public string Email { get; internal set; }
        public string Name { get; internal set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.DTOs.Requests
{
    public class JobApplicationRequest
    {
        public string CompanyName { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string? Type { get; set; }
        public int UserId { get; set; }
    }
}
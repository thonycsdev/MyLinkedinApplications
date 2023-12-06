using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Service.Enums;

namespace Service.DTOs.Responses
{
    public class JobApplicationResponse
    {
        public string CompanyName { get; set; }
        public string Role { get; set; }
        public Status Status { get; set; }
        public Types? Type { get; set; }
        public User User { get; set; }
    }
}
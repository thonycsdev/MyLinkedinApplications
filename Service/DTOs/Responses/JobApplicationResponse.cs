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
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string? Type { get; set; }
        public UserResponse User { get; set; }
    }
}
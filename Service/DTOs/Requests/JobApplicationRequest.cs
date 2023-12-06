using Service.Enums;

namespace Service.DTOs.Requests
{
    public class JobApplicationRequest
    {
        public string CompanyName { get; set; }
        public string Role { get; set; }
        public int? Status { get; set; }
        public int? Type { get; set; }
        public int UserId { get; set; }
    }
}
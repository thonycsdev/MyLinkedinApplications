namespace Domain.Entities
{
    public class JobApplication : BaseEntity
    {
        public string CompanyName { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string? Location { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
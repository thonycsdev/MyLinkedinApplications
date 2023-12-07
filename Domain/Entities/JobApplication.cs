using Service.Enums;

namespace Domain.Entities
{
    public class JobApplication : BaseEntity
    {
        public string CompanyName { get; set; }
        public string Role { get; set; }
        public Status Status { get; set; }
        public Types? Type { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}
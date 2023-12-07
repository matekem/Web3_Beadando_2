using Microsoft.AspNetCore.Identity;

namespace Web3_Beadando.Models
{
    public class Class
    {
        public Guid Id { get; set; }
        public TimeOnly StartTime { get; set; }
        public string Day { get; set; }
        public int Duration { get; set; }    
        public Guid SubjectId { get; set; }
        public Guid ClassroomId { get; set; }
    }
}
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Primitives;

namespace Web3_Beadando.Models
{
    public class Assignment
    {
        public DateTime Deadline { get; set; }
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
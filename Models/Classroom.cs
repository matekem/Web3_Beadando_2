namespace Web3_Beadando.Models
{
    public class Classroom
    {
        public string Name { get; set; }

        public Guid Id { get; set; }
        
        public Guid SubjectId { get; set; }

        public bool isLab { get; set; }
    }
}

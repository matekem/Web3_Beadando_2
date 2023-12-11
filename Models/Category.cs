namespace Web3_Beadando.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}

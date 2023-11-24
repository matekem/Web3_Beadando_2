namespace Web3_Beadando.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static Subject AddNewSubject(string name, Teacher teacher)
        {
            return new Subject
            {
                Name = name,
                Teacher = teacher
            };
        }
    }
}

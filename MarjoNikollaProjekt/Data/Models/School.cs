namespace MarjoNikollaProjekt.Data.Models
{
    public class School
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}

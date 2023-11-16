using MarjoNikollaProjekt.Data.Base;

namespace MarjoNikollaProjekt.Data.Models
{
    public class Book
    {
        internal int id;

        // Properties
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Id { get; internal set; }
    }
}

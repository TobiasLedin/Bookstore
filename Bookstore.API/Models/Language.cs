namespace Bookstore.API.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = [];

        public Language(string name)
        {
            Name = name;
        }
    }
}

namespace Bookstore.API.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Uri? Webpage { get; set; }

        public Publisher(string name)
        {
            Name = name;
        }
    }
}

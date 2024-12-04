namespace Bookstore.API.Models
{
    public class StorageLocation
    {
        public int Id { get; set; }
        public string LocationName { get; set; } = string.Empty;
        public string LocationDescription { get; set; } = string.Empty;
        public ICollection<Book> Books { get; set; } = [];

    }
}

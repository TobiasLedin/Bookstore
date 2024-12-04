namespace Bookstore.API.Models
{
    public class Rating
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public required string ISBN { get; set; }
        public int Stars { get; set; }

    }
}

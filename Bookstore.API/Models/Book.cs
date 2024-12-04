namespace Bookstore.API.Models
{
    public class Book
    {
        // PK
        public string ISBN { get; init; }
        public string Title { get; init; }
        public int AuthorId { get; set; }
        public Author? Author { get; init; }
        public int LanguageId { get; set; }
        public Language? Language { get; set; }
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; init; }
        public DateTime PublicationDate { get; init; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public ICollection<StorageLocation> StorageLocations { get; set; } = [];
        public ICollection<Rating> Ratings { get; set; } = [];

        public Book(string isbn, string title, int authorId, int publisherID, DateTime publicationDate, int categoryId)
        {
            ISBN = isbn;
            Title = title;
            AuthorId = authorId;
            PublisherId = publisherID;
            PublicationDate = publicationDate;
            CategoryId = categoryId;
        }
    }
}

namespace Bookstore.API.Models
{
    public class Book : Product
    {
        public string ISBN { get; init; }
        public DateTime PublicationDate { get; init; }
        public int AuthorId { get; set; }
        public int LanguageId { get; set; }
        public int PublisherId { get; set; }
        public int GenreId { get; set; }

        // Nav properties
        public Author? Author { get; init; }
        public Language? Language { get; set; }
        public Publisher? Publisher { get; init; }
        public Genre? Genre { get; set; }

        public Book(string name, string description, string isbn, string title, int authorId, int publisherId, DateTime publicationDate, int categoryId, double weight)
            : base(name, description, categoryId, weight)
        {
            ISBN = isbn ?? throw new ArgumentException("ISBN cannot be null");
            AuthorId = authorId;
            PublisherId = publisherId;
            PublicationDate = publicationDate;
            GenreId = categoryId;
        }
    }
}

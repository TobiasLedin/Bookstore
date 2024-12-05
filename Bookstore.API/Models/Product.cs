namespace Bookstore.API.Models
{
    public abstract class Product
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public double Weight { get; set; }
        public bool InStock => StockQuantity > 0;
        public int StockQuantity { get; set; }
        public int StockRefillQuantity { get; set; }

        // Nav properties
        public ProductCategory? Category { get; set; }
        public ICollection<StorageLocation> StorageLocations { get; set; } = [];
        public ICollection<Rating> Ratings { get; set; } = [];

        protected Product(string name, string description, int categoryId, double weight)
        {
            Id = Guid.CreateVersion7();
            Name = name ?? throw new ArgumentException("Product name cannot be null");
            Description = description;
            CategoryId = categoryId;
            Weight = weight;
        }
    }
}

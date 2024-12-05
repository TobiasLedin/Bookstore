using Bookstore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        // Book related
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<StorageLocation> StorageLocations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => 
            options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? throw new NullReferenceException("Database connection string not loaded"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // Book - Author relation
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany()
                .HasForeignKey(b => b.AuthorId);

            // Book - Language relation
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Language)
                .WithMany()
                .HasForeignKey(b => b.LanguageId);

            // Book - Publisher relation
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany()
                .HasForeignKey(b => b.PublisherId);

            // Book - Ratings relation
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Ratings)
                .WithOne()
                .HasForeignKey(r => r.Id);

            // Book - StorageLocation relation
            // EF setup to manage join table
            modelBuilder.Entity<Book>()
                .HasMany(b => b.StorageLocations)
                .WithMany(sl => sl.Books)
                .UsingEntity(j => j.ToTable("BookStorageLocations"));
        }
    }
}

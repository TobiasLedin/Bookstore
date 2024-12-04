using Bookstore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        

        protected override void OnConfiguring(DbContextOptionsBuilder options) => 
            options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? throw new NullReferenceException("Database connection string not loaded"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Book 
            modelBuilder.Entity<Book>()
                .HasKey(b => b.ISBN);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany()
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Language)
                .WithMany()
                .HasForeignKey(b => b.LanguageId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany()
                .HasForeignKey(b => b.PublisherId);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Ratings)
                .WithOne()
                .HasForeignKey(r => r.Id);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.StorageLocations)
                .WithMany(sl => sl.Books)
                .UsingEntity(j => j.ToTable("BookStorageLocations"));
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MyApp.Adapters.Output.Entities;
using MyApp.Domain.Models;

namespace MyApp.Adapters.Output.Context
{
    public class InMemoryContext : DbContext
    {
        internal DbSet<BookEntity> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "InMemory");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            IList<BookEntity> defaultBooks = new List<BookEntity>();

            defaultBooks.Add(new BookEntity() { Id = 1, Price = (decimal?)1.1, Title = "Book1" });
            defaultBooks.Add(new BookEntity() { Id = 2, Price = (decimal?)1.2, Title = "Book2" });
            defaultBooks.Add(new BookEntity() { Id = 3, Title = "Book3" });

            modelBuilder.Entity<BookEntity>()
                .HasData(defaultBooks);
        }

    }
}

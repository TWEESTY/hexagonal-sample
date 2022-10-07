using Microsoft.EntityFrameworkCore;
using MyApp.Adapters.Output.Entities;
using MyApp.Domain.Models;

namespace MyApp.Adapters.Output.Context
{
    public class InMemoryContext : DbContext
    {
        internal DbSet<BookEntity> Books { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "InMemory");

        }}


}

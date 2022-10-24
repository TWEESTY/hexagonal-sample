using Microsoft.EntityFrameworkCore;
using MyApp.Adapters.Output.Context;
using MyApp.Adapters.Output.Entities;
using MyApp.Application.Ports.Output.Repositories;
using MyApp.Domain.Models;

namespace MyApp.Adapters.Output.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly InMemoryContext _context;

        public BookRepository(InMemoryContext context, bool initDatabase = true)
        {
            this._context = context;

            // Trick to force the OnModelCreating (i.e. https://github.com/dotnet/efcore/issues/11666)
            if (initDatabase)
                this._context.Database.EnsureCreated();
        }

        public async Task<Book?> GetBookAsync(int id) { 
            BookEntity? bookEntity = await this._context.Books.FirstOrDefaultAsync(x => x.Id == id); 
            if (bookEntity == null)
            {
                return null;
            }

            MutableBook book = BookFactory.Instance.CreateMutableBook(id);
            book.Price = bookEntity.Price;
            book.Title = bookEntity.Title;

            return book;
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            BookEntity? bookEntity = await this._context.Books.FirstOrDefaultAsync(x => x.Id == book.Id);
            if (bookEntity == null)
            {
                return false;
            }

            bookEntity.Price = book.Price;
            bookEntity.Title = book.Title;

            return true;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return this._context.SaveChangesAsync(cancellationToken);
        }
    }
}
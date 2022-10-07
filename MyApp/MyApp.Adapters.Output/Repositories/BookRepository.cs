using MyApp.Adapters.Output.Context;
using MyApp.Adapters.Output.Entities;
using MyApp.Application.Ports.Output.Repositories;
using MyApp.Domain.Models;
using System.Reflection.Metadata;

namespace MyApp.Adapters.Output.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly InMemoryContext _context;

        public BookRepository(InMemoryContext context)
        {
            this._context = context;
        }

        public Book? GetBook(int id) { 
            BookEntity? bookEntity = this._context.Books.FirstOrDefault(x => x.Id == id); 
            if (bookEntity == null)
            {
                return null;
            }

            MutableBook book = BookFactory.Instance.CreateMutableBook(id);
            book.Price = bookEntity.Price;
            book.Title = bookEntity.Title;

            return book;
        }

        public bool UpdateBook(Book book)
        {
            BookEntity? bookEntity = this._context.Books.FirstOrDefault(x => x.Id == id);
            if (bookEntity == null)
            {
                return false;
            }

            bookEntity.Price = book.Price;
            bookEntity.Title = book.Title;

            this._context.SaveChanges();

            return true;
        }
    }
}
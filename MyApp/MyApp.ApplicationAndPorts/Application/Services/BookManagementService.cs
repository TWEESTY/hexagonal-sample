using MyApp.Application.Ports.Input.BookManagementService;
using MyApp.Application.Ports.Output.Repositories;
using MyApp.Domain.Models;

namespace MyApp.Application.Application.Services
{
    public class BookManagementService : IBookManagementService
    {
        private readonly IBookRepository _bookRepository;

        public BookManagementService(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        public Book GetBook(int id)
        {
            return this._bookRepository.GetBook(id);
        }

        public bool UpdateBook(Book book)
        {
            return this._bookRepository.UpdateBook(book);
        }
    }
}

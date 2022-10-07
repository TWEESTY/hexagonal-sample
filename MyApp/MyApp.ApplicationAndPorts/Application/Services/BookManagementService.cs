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

        public async Task<Book?> GetBookAsync(int id)
        {
            return await this._bookRepository.GetBookAsync(id);
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            return await this._bookRepository.UpdateBookAsync(book);
        }
    }
}

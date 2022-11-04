using MyApp.Application.Ports.Input;
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

        public Task<Book?> GetBookAsync(int id)
        {
            return this._bookRepository.GetBookAsync(id);
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            bool updated = await this._bookRepository.UpdateBookAsync(book);
            if (!updated)
            {
                return false;
            }

            await this._bookRepository.SaveChangesAsync();
            return true;
        }
    }
}

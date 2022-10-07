using MyApp.Domain.Models;

namespace MyApp.Application.Ports.Input.BookManagementService
{
    public interface IBookManagementService
    {
        public Task<Book?> GetBookAsync(int id);
        public Task<bool> UpdateBookAsync(Book book);
    }
}

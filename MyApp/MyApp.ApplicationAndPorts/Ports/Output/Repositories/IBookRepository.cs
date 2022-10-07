using MyApp.Domain.Models;

namespace MyApp.Application.Ports.Output.Repositories
{
    public interface IBookRepository : IRepository
    {
        public Task<Book?> GetBookAsync(int id);
        public Task<bool> UpdateBookAsync(Book book);
    }
}

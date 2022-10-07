using MyApp.Domain.Models;

namespace MyApp.Application.Ports.Input.BookManagementService
{
    public interface IBookManagementService
    {
        public Book GetBook(int id);
        public bool UpdateBook(Book book);
    }
}

using MyApp.Domain.Models;

namespace MyApp.Domain.Services
{
    public class DummyService
    {
        public int DoSomething(Book book)
        {
            return book.Id;
        }
    }
}

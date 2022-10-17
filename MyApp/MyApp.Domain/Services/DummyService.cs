using MyApp.Domain.Models;

namespace MyApp.Domain.Services
{
    public class DummyService
    {
        public int ReturnsId(Book book)
        {
            return book.Id;
        }
    }
}

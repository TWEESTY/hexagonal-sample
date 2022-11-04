using MyApp.Domain.Models;
using MyApp.Domain.Services;

namespace MyApp.Domain.Tests.Services
{
    public class DummyServiceTests
    {
        [Fact]
        public void ReturnsId_CorrectBook_ShouldReturnId()
        {
            MutableBook returnBookByService = BookFactory.Instance.CreateMutableBook(1);
            returnBookByService.Price = 2;
            returnBookByService.Title = "Super book";

            var dummyService = new DummyService();

            int result = dummyService.ReturnsId(returnBookByService);

            Assert.Equal(returnBookByService.Id, result);
        }
    }
}

using Moq;
using MyApp.Application.Ports.Output.Repositories;
using MyApp.Domain.Models;
using MyApp.Application.Application.Services;

namespace MyApp.Application.Tests.Application.Services
{
    public class BookManagementServiceTests
    {
        [Fact]
        public async void GetBookAsync_ExistingBook_ShouldReturnBook()
        {
            MutableBook returnBookFromRepo = BookFactory.Instance.CreateMutableBook(1);
            returnBookFromRepo.Price = 2;
            returnBookFromRepo.Title = "Super book";

            var mockBookRepository = new Mock<IBookRepository>();
            mockBookRepository.Setup(m => m.GetBookAsync(It.IsAny<int>())).ReturnsAsync(returnBookFromRepo);

            var bookManagementService = new BookManagementService(mockBookRepository.Object);

            Book? resultBook = await bookManagementService.GetBookAsync(returnBookFromRepo.Id);

            Assert.NotNull(resultBook);
            Assert.Equivalent(returnBookFromRepo, resultBook);
        }

        [Fact]
        public async void GetBookAsync_NoExistingBook_ShouldReturnNull()
        {
            MutableBook returnBookFromRepo = BookFactory.Instance.CreateMutableBook(1);
            returnBookFromRepo.Price = 2;
            returnBookFromRepo.Title = "Super book";

            var mockBookRepository = new Mock<IBookRepository>();
            mockBookRepository.Setup(m => m.GetBookAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            var bookManagementService = new BookManagementService(mockBookRepository.Object);

            Book? resultBook = await bookManagementService.GetBookAsync(returnBookFromRepo.Id);

            Assert.Null(resultBook);
        }

        [Fact]
        public async void UpdateBookAsync_ExistingBook_ShouldReturnTrue()
        {
            MutableBook bookToUpdate = BookFactory.Instance.CreateMutableBook(1);
            bookToUpdate.Price = 2;
            bookToUpdate.Title = "Super book";

            var mockBookRepository = new Mock<IBookRepository>();
            mockBookRepository.Setup(m => m.UpdateBookAsync(It.IsAny<Book>())).ReturnsAsync(true);

            var bookManagementService = new BookManagementService(mockBookRepository.Object);

            bool result = await bookManagementService.UpdateBookAsync(bookToUpdate);

            Assert.True(result);
            mockBookRepository.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async void UpdateBookAsync_NoExistingBook_ShouldReturnFalse()
        {
            MutableBook bookToUpdate = BookFactory.Instance.CreateMutableBook(1);
            bookToUpdate.Price = 2;
            bookToUpdate.Title = "Super book";

            var mockBookRepository = new Mock<IBookRepository>();
            mockBookRepository.Setup(m => m.UpdateBookAsync(It.IsAny<Book>())).ReturnsAsync(false);

            var bookManagementService = new BookManagementService(mockBookRepository.Object);

            bool result = await bookManagementService.UpdateBookAsync(bookToUpdate);

            Assert.False(result);
            mockBookRepository.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

    }
}

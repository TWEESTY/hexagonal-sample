using Moq;
using MyApp.Domain.Models;
using MyApp.Adapters.Input.Rest.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApp.Adapters.Input.Rest.AutoMapper;
using MyApp.Application.Ports.Input;

namespace MyApp.Adapters.Input.Rest.Tests.Controllers
{
    public class BookControllerTests
    {
        private IMapper _mapper;

        public BookControllerTests() {

            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BookProfile>()));
        }

        [Fact]
        public void GetBook_ExistingBook_ShouldReturnOk()
        {
            MutableBook returnBookByService = BookFactory.Instance.CreateMutableBook(1);
            returnBookByService.Price = 2;
            returnBookByService.Title = "Super book";

            var mockBookManagementService = new Mock<IBookManagementService>();
            mockBookManagementService.Setup(m => m.GetBookAsync(It.IsAny<int>())).ReturnsAsync(returnBookByService);

            var bookController = 
                new BookController(mockBookManagementService.Object, this._mapper);

            IActionResult result = bookController.GetBook(returnBookByService.Id);

            Assert.IsType<OkObjectResult>(result);

            var resultBook = ((BookDTO)((OkObjectResult)result).Value);
            Assert.True(IsEqual(returnBookByService, resultBook));
        }

        [Fact]
        public void GetBook_NoExistingBook_ShouldReturnNotFound()
        {
            var mockBookManagementService = new Mock<IBookManagementService>();
            mockBookManagementService.Setup(m => m.GetBookAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            var bookController =
                new BookController(mockBookManagementService.Object, this._mapper);

            IActionResult result = bookController.GetBook(1);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void CompleteUpdateBook_ExistingBook_ShouldReturnOk() 
        {
            var bookToUpdate = new BookDTO()
            {
                Id = 1,
                Price = 2,
                Title = "Super book"
            };

            var mockBookManagementService = new Mock<IBookManagementService>();
            mockBookManagementService.Setup(m => m.UpdateBookAsync(It.IsAny<Book>())).ReturnsAsync(true);

            var bookController =
                new BookController(mockBookManagementService.Object, this._mapper);

            IActionResult result = bookController.CompleteUpdateBook(bookToUpdate);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CompleteUpdateBook_NonExistingBook_ShouldReturnNotFound()
        {
            var bookToUpdate = new BookDTO()
            {
                Id = 1,
                Price = 2,
                Title = "Super book"
            };

            var mockBookManagementService = new Mock<IBookManagementService>();
            mockBookManagementService.Setup(m => m.UpdateBookAsync(It.IsAny<Book>())).ReturnsAsync(false);

            BookController bookController =
                new BookController(mockBookManagementService.Object, this._mapper);

            IActionResult result = bookController.CompleteUpdateBook(bookToUpdate);

            Assert.IsType<NotFoundResult>(result);
        }


        private bool IsEqual(Book? book, BookDTO? bookDTO)
        {
            if (book == null && bookDTO == null)
                return true;

            if(book == null && bookDTO != null)
                return false;

            if (book != null && bookDTO == null)
                return false;

            return book.Id == bookDTO.Id
                   && book.Title == bookDTO.Title
                   && book.Price == Convert.ToDecimal(bookDTO.Price);
        }
    }
}

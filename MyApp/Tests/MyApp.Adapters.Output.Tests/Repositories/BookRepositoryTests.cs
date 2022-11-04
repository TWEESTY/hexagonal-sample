using MockQueryable.Moq;
using Moq;
using MyApp.Adapters.Output.Context;
using MyApp.Adapters.Output.Entities;
using MyApp.Adapters.Output.Repositories;
using MyApp.Adapters.Output.Tests.Extensions;
using MyApp.Domain.Models;

namespace MyApp.Adapters.Output.Tests.Repositories
{
    public class BookRepositoryTests
    {
        [Fact]
        public async void GetBookAsync_ExistingBook_ShouldReturnBook()
        {
            var idBookToGet = 2;
            var booksInRepository = new List<BookEntity>
            {
                new BookEntity() { Id = 1, Price = (decimal?)1.1, Title = "Book1" },
                new BookEntity() { Id = 2, Price = (decimal?)1.2, Title = "Book2" },
                new BookEntity() { Id = 3, Title = "Book3" }
            };

            var booksSet = booksInRepository.AsQueryable().BuildMockDbSet();

            var context = new Mock<InMemoryContext>();
            context.Setup(c => c.Books).Returns(booksSet.Object);

            var repository = new BookRepository(context.Object, initDatabase: false);

            var returnBook = await repository.GetBookAsync(idBookToGet);

            Assert.NotNull(returnBook);
            Assert.Equivalent(booksInRepository.Single(b => b.Id == idBookToGet), returnBook);
        }

        [Fact]
        public async void GetBookAsync_NoExistingBook_ShouldReturnNull()
        {
            var idBookToGet = 4;
            var booksInRepository = new List<BookEntity>
            {
                new BookEntity() { Id = 1, Price = (decimal?)1.1, Title = "Book1" },
                new BookEntity() { Id = 2, Price = (decimal?)1.2, Title = "Book2" },
                new BookEntity() { Id = 3, Title = "Book3" }
            };

            var booksSet = booksInRepository.AsQueryable().BuildMockDbSet();

            var context = new Mock<InMemoryContext>();
            context.Setup(c => c.Books).Returns(booksSet.Object);

            var repository = new BookRepository(context.Object, initDatabase: false);

            var returnBook = await repository.GetBookAsync(idBookToGet);

            Assert.Null(returnBook);
        }

        [Fact]
        public async void UpdateBookAsync_ExistingBook_ShouldReturnTrue()
        {
            var idBookToUpdate = 2;
            var booksInRepository = new List<BookEntity>
            {
                new BookEntity() { Id = 1, Price = (decimal?)1.1, Title = "Book1" },
                new BookEntity() { Id = 2, Price = (decimal?)1.2, Title = "Book2" },
                new BookEntity() { Id = 3, Title = "Book3" }
            };

            var initialBooksInRepository = booksInRepository.Clone();

            MutableBook bookToUpdate = BookFactory.Instance.CreateMutableBook(idBookToUpdate);
            bookToUpdate.Price = 9999;
            bookToUpdate.Title = "Updated book";

            var booksSet = booksInRepository.AsQueryable().BuildMockDbSet();

            var context = new Mock<InMemoryContext>();
            context.Setup(c => c.Books).Returns(booksSet.Object);

            var repository = new BookRepository(context.Object, initDatabase: false);

            var result = await repository.UpdateBookAsync(bookToUpdate);

            Assert.True(result);
            Assert.Equal(bookToUpdate.Price, booksInRepository.Single(x => x.Id == idBookToUpdate).Price);
            Assert.Equal(bookToUpdate.Title, booksInRepository.Single(x => x.Id == idBookToUpdate).Title);
            booksInRepository
                .Where(b => b.Id != idBookToUpdate).ToList()
                .ForEach(b => Assert.Equivalent(b, initialBooksInRepository.Single(x => x.Id == b.Id)));
        }

        [Fact]
        public async void UpdateBookAsync_NoExistingBook_ShouldReturnFalse()
        {
            var idBookToUpdate = 4;
            var booksInRepository = new List<BookEntity>
            {
                new BookEntity() { Id = 1, Price = (decimal?)1.1, Title = "Book1" },
                new BookEntity() { Id = 2, Price = (decimal?)1.2, Title = "Book2" },
                new BookEntity() { Id = 3, Title = "Book3" }
            };

            var initialBooksInRepository = booksInRepository.Clone();

            MutableBook bookToUpdate = BookFactory.Instance.CreateMutableBook(idBookToUpdate);
            bookToUpdate.Price = 9999;
            bookToUpdate.Title = "Updated book";

            var booksSet = booksInRepository.AsQueryable().BuildMockDbSet();

            var context = new Mock<InMemoryContext>();
            context.Setup(c => c.Books).Returns(booksSet.Object);

            var repository = new BookRepository(context.Object, initDatabase: false);

            var result = await repository.UpdateBookAsync(bookToUpdate);

            Assert.False(result);
            Assert.Equivalent(initialBooksInRepository, booksInRepository);
        }
    }
}
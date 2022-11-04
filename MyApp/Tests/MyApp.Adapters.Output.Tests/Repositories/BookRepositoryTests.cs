namespace MyApp.Adapters.Output.Tests.Repositories
{
    public class BookRepositoryTests
    {
        /**
         * 
         * IBookRepository
InMemoryContext

Book? = GetBookAsync(int id)
bool = UpdateBookAsync(Book book)
         */

        [Fact]
        public async void GetBookAsync_ExistingBook_ShouldReturnBook()
        {

        }

        [Fact]
        public async void GetBookAsync_NoExistingBook_ShouldReturnNull()
        {
        
        }

        [Fact]
        public async void UpdateBookAsync_ExistingBook_ShouldReturnBool()
        {

        }

        [Fact]
        public async void UpdateBookAsync_NoExistingBook_ShouldReturnFalse()
        {

        }

    }
}

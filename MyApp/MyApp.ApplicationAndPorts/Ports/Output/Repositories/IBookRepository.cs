namespace MyApp.Application.Ports.Output.Repositories
{
    public interface IBookRepository
    {
        public Book GetBook(int id);
        public bool UpdateBook(Book book);
    }
}

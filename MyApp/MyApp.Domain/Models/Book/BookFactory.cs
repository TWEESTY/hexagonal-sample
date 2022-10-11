namespace MyApp.Domain.Models
{
    public class BookFactory
    {
        private static readonly BookFactory instance = new();

        static BookFactory()
        {
        }

        private BookFactory()
        {
        }

        public static BookFactory Instance
        {
            get
            {
                return instance;
            }
        }

        internal Book CreateBook(int id)
        {
            return new Book(id);
        }

        public MutableBook CreateMutableBook(int id)
        {
            return new MutableBook(id);
        }
    }
}

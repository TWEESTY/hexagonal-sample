namespace MyApp.Domain.Models
{
    public class MutableBook : Book
    {
        public new string? Title
        {
            get => base.Title;
            set => base.Title = value;
        }

        public new decimal? Price
        {
            get => base.Price;
            set => base.Price = value;
        }


        internal MutableBook(int id) : base(id)
        {
        }
    }
}

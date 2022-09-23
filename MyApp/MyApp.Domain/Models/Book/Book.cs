using MyApp.Domain.Common;

namespace MyApp.Domain.Models
{
    public class Book : AggregateRoot<int>
    {
        protected string? _title;
        protected decimal? _price;

        public int Id { get; init; }
        public virtual string? Title
        {
            get => this._title;
            internal set => this._title = value;
        }
                
        public virtual decimal? Price
        {
            get => this._price;
            internal set => this._price = value;
        }

        internal Book(int id) {
            this.Id = id;
        }
    }
}

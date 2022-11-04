using MyApp.Domain.Common;

namespace MyApp.Domain.Models
{
    public class Store : AggregateRoot<int>
    {
        public string? Code { get; init; }

        public string? Name { get; internal set; }

        internal Store(string? code)
        {
            this.Code = code;
        }

        // Constructor using an "Input Data Object"
        internal Store(IStoreIDO ido)
        {
            this.Code = ido.Code;
            this.Name = ido.Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Adapters.Output.Entities
{
    internal class BookEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal? Price { get; set; }
    }
}

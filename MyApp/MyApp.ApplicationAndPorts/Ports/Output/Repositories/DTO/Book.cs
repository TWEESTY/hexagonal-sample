using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Ports.Output.Repositories
{
    public class Book
    {
        int Id { get; set; }
        public string? Title { get; set; }
        public double Price { get; set; }
    }
}

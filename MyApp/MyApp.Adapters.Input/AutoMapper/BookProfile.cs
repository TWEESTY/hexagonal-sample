using AutoMapper;
using Book = MyApp.Application.Ports.Output.Repositories.Book;

namespace MyApp.Adapters.Input.AutoMapper
{
    internal class BookProfile : Profile
    {
        internal BookProfile() {
            this.CreateMap<Book, MyApp.Application.Book>()
              .ReverseMap();
        }
    }
}

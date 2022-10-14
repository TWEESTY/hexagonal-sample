using AutoMapper;
using MyApp.Adapters.Input.Rest.Controllers;
using MyApp.Domain.Models;

namespace MyApp.Adapters.Input.Rest.AutoMapper
{
    internal class BookProfile : Profile
    {
        public BookProfile() {
            
            this.CreateMap<Book, BookDTO>();
            this.CreateMap<BookDTO, Book>()
                .ConstructUsing((BookDTO bookDTO) => BookFactory.Instance.CreateMutableBook(bookDTO.Id));
        }
    }
}

using AutoMapper;
using MyApp.Adapters.Input.Controllers;
using MyApp.Domain.Models;

namespace MyApp.Adapters.Input.AutoMapper
{
    public class BookProfile : Profile
    {
        public BookProfile() {
            
            this.CreateMap<Book, BookDTO>();
            this.CreateMap<BookDTO, Book>()
                .ConstructUsing((BookDTO bookDTO) => BookFactory.Instance.CreateMutableBook(bookDTO.Id));
        }
    }
}

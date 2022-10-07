using AutoMapper;
using MyApp.Adapters.Input.Controllers;
using MyApp.Domain.Models;

namespace MyApp.Adapters.Input.AutoMapper
{
    internal class BookProfile : Profile
    {
        internal BookProfile() {
            this.CreateMap<BookDTO, Book>()
              .ReverseMap();
        }
    }
}

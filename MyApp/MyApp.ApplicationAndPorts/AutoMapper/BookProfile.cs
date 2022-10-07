using AutoMapper;

namespace MyApp.Application.AutoMapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<MyApp.Application.Book, MyApp.Application.Ports.Output.Repositories.Book>()
                .ReverseMap();
        }
    }
}

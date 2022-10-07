using AutoMapper;
using MyApp.Application.Ports.Input.BookManagementService;
using MyApp.Application.Ports.Output.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book = MyApp.Application.Book;

namespace MyApp.Application.Application.Services
{
    public class BookManagementService : IBookManagementService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookManagementService(IBookRepository bookRepository, IMapper mapper)
        {
            this._bookRepository = bookRepository;
            this._mapper = mapper;
        }

        public Book GetBook(int id)
        {
            Ports.Output.Repositories.Book bookFromRepo = this._bookRepository.GetBook(id);
            return this._mapper.Map<Book>(bookFromRepo);
        }

        public bool UpdateBook(Book book)
        {
            Ports.Output.Repositories.Book bookToRepo = this._mapper.Map<Ports.Output.Repositories.Book>(book);
            return this._bookRepository.UpdateBook(bookToRepo);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Ports.Input.BookManagementService;
using MyApp.Domain.Models;

namespace MyApp.Adapters.Input.Rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookManagementService _bookManagementService;
        private readonly IMapper _mapper;

        public BookController(IBookManagementService bookManagementService, IMapper mapper)
        {
            this._bookManagementService = bookManagementService;
            this._mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBook(int id)
        {
            Book? bookFromApplication = this._bookManagementService.GetBookAsync(id).GetAwaiter().GetResult();

            if (bookFromApplication == null)
            {
                return NotFound();
            }

            BookDTO book = this._mapper.Map<BookDTO>(bookFromApplication);

            return Ok(book);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CompleteUpdateBook(BookDTO updateBook)
        {
            bool result = this._bookManagementService.UpdateBookAsync(this._mapper.Map<Book>(updateBook)).GetAwaiter().GetResult();

            // Non réaliste
            if(!result)
                return NotFound(); 

            return Ok(updateBook);
        }


    }
}
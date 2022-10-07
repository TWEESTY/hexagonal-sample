using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyApp.Application.Application.Services;
using MyApp.Application.Ports.Input.BookManagementService;
using MyApp.Domain.Models;

namespace MyApp.Adapters.Input.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookManagementService _bookManagementService;
        private readonly IMapper _mapper;

        public BookController(ILogger<BookController> logger, IBookManagementService bookManagementService, IMapper mapper)
        {
            this._logger = logger;
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
                return BadRequest(); 

            return Ok(updateBook);
        }


    }
}
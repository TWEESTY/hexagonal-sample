using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Application.Services;

namespace MyApp.Adapters.Input.Controllers
{
    [ApiController]
    [Route("[book]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly BookManagementService _bookManagementService;
        private readonly IMapper _mapper;

        public BookController(ILogger<BookController> logger, BookManagementService bookManagementService, IMapper mapper)
        {
            this._logger = logger;
            this._bookManagementService = bookManagementService;
            this._mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBook(int id)
        {
            MyApp.Application.Book bookFromApplication = this._bookManagementService.GetBook(id);
            Book book = this._mapper.Map<Book>(bookFromApplication);

            if (bookFromApplication == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CompleteUpdateBook(Book updateBook)
        {
            bool result = this._bookManagementService.UpdateBook(this._mapper.Map<MyApp.Application.Book>(updateBook));

            // Non réaliste
            if(!result)
                return BadRequest(); 

            return Ok(updateBook);
        }


    }
}
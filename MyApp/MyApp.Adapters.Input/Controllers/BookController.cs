using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Application.Services;
using MyApp.Domain.Models;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBook(int id)
        {
            Book bookFromApplication = this._bookManagementService.GetBook(id);
            BookDTO book = this._mapper.Map<BookDTO>(bookFromApplication);

            if (bookFromApplication == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CompleteUpdateBook(BookDTO updateBook)
        {
            bool result = this._bookManagementService.UpdateBook(this._mapper.Map<Book>(updateBook));

            // Non r�aliste
            if(!result)
                return BadRequest(); 

            return Ok(updateBook);
        }


    }
}
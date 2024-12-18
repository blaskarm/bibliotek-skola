using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Books.Commands.CreateBook;
using Application.Dtos;
using Application.Books.Commands.UpdateBook;
using Application.Books.Queries.GetBooks;
using Application.Books.Commands.DeleteBook;
using Application.Utilities;


namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllBooksQuery()));
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var book = await _mediator.Send(new GetBookByIdQuery(id));

                return book is not null ? Ok(book) : NotFound("Book not found.");
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookDto bookToAdd)
        {
            try
            {
                Result<BookDto> result = await _mediator.Send(new CreateBookCommand(bookToAdd));

                return result.IsSuccess ? Ok($"({result.Data.Title}) {result.Message}") : BadRequest(result.Message);
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BookDto bookToAdd)
        {
            try
            {
                Result<BookDto> result = await _mediator.Send(new UpdateBookCommand(id, bookToAdd));

                return result.IsSuccess ? Ok($"({result.Data.Title}) {result.Message}") : BadRequest(result.Message);
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Result<BookDto> result = await _mediator.Send(new DeleteBookCommand(id));

                return result.IsSuccess ? Ok(result.Message) : NotFound(result.Message);
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}

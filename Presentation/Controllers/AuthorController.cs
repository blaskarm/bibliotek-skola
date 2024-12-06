using Application.Authors.Commands.CreateAuthor;
using Application.Authors.Commands.DeleteAuthor;
using Application.Authors.Commands.UpdateAuthor;
using Application.Authors.Queries;
using Application.Dtos;
using Application.Utilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllAuthorsQuery()));
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
            
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var author = await _mediator.Send(new GetAuthorByIdQuery(id));

                return author is not null ? Ok(author) : NotFound("Author not found");
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthorDto author)
        {
            try
            {
                Result<AuthorDto> result = await _mediator.Send(new CreateAuthorCommand(author));

                return result.IsSuccess ? Ok($"({result.Data.Name}) {result.Message}") : BadRequest(result.Message);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AuthorDto author)
        {
            try
            {
                Result<AuthorDto> result = await _mediator.Send(new UpdateAuthorCommand(id, author));

                return result.IsSuccess ? Ok($"({result.Data.Name}) {result.Message}") : BadRequest(result.Message);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Result<AuthorDto> result = await _mediator.Send(new DeleteAuthorCommand(id));

                return result.IsSuccess ? Ok(result.Message) : NotFound(result.Message);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

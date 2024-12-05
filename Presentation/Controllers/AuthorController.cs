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
            return Ok(await _mediator.Send(new GetAllAuthorsQuery()));
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var author = await _mediator.Send(new GetAuthorByIdQuery(id));

            return author is not null ? Ok(author) : NotFound("Author not found");
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthorDto author)
        {
            Result<AuthorDto> result = await _mediator.Send(new CreateAuthorCommand(author));

            return result.IsSuccess ? Ok($"({result.Data.Name}) {result.Message}") : BadRequest(result.Message);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AuthorDto author)
        {
            Result<AuthorDto> result = await _mediator.Send(new UpdateAuthorCommand(id, author));

            return result.IsSuccess ? Ok($"({result.Data.Name}) {result.Message}") : BadRequest(result.Message);
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Result<AuthorDto> result = await _mediator.Send(new DeleteAuthorCommand(id));

            return result.IsSuccess ? Ok(result.Message) : NotFound(result.Message);
        }
    }
}

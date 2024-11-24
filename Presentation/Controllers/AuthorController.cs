﻿using Application.Authors.Commands.CreateAuthor;
using Application.Authors.Commands.DeleteAuthor;
using Application.Authors.Commands.UpdateAuthor;
using Application.Authors.Queries;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

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
            return Ok(await _mediator.Send(new GetAuthorByIdQuery(id)));
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthorDto author)
        {
            bool result = await _mediator.Send(new CreateAuthorCommand(author));
            if (!result)
                return BadRequest();

            return Ok();
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AuthorDto author)
        {
            bool result = await _mediator.Send(new UpdateAuthorCommand(id, author));
            if (!result)
                return BadRequest();

            return Ok();
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _mediator.Send(new DeleteAuthorCommand(id));
            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}

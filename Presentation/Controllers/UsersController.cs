using Application.Dtos;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetAllUsers;
using Application.Users.Queries.GetUserById;
using Application.Users.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        // GET: api/<UsersController>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllUsersQuery()));
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByIdQuery(id));
                return user is null ? NotFound("User not found") : Ok(user);
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDto user)
        {
            try
            {
                bool result = await _mediator.Send(new UpdateUserCommand(id, user));

                return !result ? BadRequest() : Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _mediator.Send(new DeleteUserCommand(id));

                return !result ? BadRequest() : Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserDto user)
        {
            try
            {
                return Ok(await _mediator.Send(new CreateUserCommand(user)));
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserDto user)
        {
            try
            {
                return Ok(await _mediator.Send(new LoginUserQuery(user)));
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}

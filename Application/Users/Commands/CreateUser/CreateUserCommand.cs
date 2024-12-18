using Application.Dtos;
using Application.Utilities;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public record CreateUserCommand(UserDto User) : IRequest<Result<UserDto>>;
}

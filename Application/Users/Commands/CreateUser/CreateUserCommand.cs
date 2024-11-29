using Application.Dtos;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public record CreateUserCommand(UserDto User) : IRequest<bool>;
}

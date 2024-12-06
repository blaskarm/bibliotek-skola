using Application.Dtos;
using MediatR;

namespace Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(int Id, UserDto User) : IRequest<bool>;
}

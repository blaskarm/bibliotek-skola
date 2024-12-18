using Application.Dtos;
using Application.Utilities;
using MediatR;

namespace Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(int Id, UserDto User) : IRequest<Result<UserDto>>;
}

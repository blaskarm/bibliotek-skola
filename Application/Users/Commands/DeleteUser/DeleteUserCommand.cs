using Application.Dtos;
using Application.Utilities;
using MediatR;

namespace Application.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(int Id) : IRequest<Result<UserDto>>;
}

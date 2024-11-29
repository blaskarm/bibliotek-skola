using Application.Dtos;
using MediatR;

namespace Application.Users.Queries.Login
{
    public record LoginUserQuery(UserDto User) : IRequest<string>;
}

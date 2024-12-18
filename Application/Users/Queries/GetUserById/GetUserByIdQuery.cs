using Application.Utilities;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(int Id) : IRequest<Result<User>>;
}

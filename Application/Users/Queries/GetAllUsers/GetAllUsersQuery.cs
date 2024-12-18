using Application.Utilities;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery : IRequest<Result<List<User>>>;
}

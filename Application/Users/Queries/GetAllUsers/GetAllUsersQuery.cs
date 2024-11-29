using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery : IRequest<List<User>>;
}

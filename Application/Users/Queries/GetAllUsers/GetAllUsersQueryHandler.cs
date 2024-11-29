using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IFakeDatabase _database;

        public GetAllUsersQueryHandler(IFakeDatabase database)
        {
            _database = database;
        }

        public Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> users = _database.Users;
            return Task.FromResult(users);
        }
    }
}

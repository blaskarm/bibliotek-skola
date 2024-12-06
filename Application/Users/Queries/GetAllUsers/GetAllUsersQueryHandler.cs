using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler(IUserRepository repository) : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUserRepository _repository = repository;

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<User> users = await _repository.GetAllAsync();
            return users.ToList();
        }
    }
}

using Application.Interfaces;
using Application.Utilities;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler(IUserRepository repository) : IRequestHandler<GetAllUsersQuery, Result<List<User>>>
    {
        private readonly IUserRepository _repository = repository;

        public async Task<Result<List<User>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<User> users = await _repository.GetAllAsync();
                return Result<List<User>>.Success(users.ToList());
            }
            catch
            {
                return Result<List<User>>.Failure("Something went wrong");
            }
        }
    }
}

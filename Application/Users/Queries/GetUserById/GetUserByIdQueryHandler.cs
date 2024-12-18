using Application.Interfaces;
using Application.Utilities;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler(IUserRepository repository) : IRequestHandler<GetUserByIdQuery, Result<User>>
    {
        private readonly IUserRepository _repository = repository;

        public async Task<Result<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            return user is null ? Result<User>.Failure("User not found.") : Result<User>.Success(user);
        }
    }
}

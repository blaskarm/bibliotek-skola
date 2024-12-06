using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler(IUserRepository repository) : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _repository = repository;

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            return user is not null ? user : null!;
        }
    }
}

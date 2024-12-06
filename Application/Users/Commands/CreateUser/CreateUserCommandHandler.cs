using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler(IUserRepository repository) : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _repository = repository;

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.UserExists(request.User.UserName))
                return false;

            var user = new User
            {
                UserName = request.User.UserName,
                Password = request.User.Password,
            };

            await _repository.AddAsync(user);

            return true;
        }
    }
}

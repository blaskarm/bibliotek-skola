using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler(IFakeDatabase database) : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IFakeDatabase _database = database;

        public Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User newUser = new()
            {
                Id = _database.Users.Max(u => u.Id) + 1,
                UserName = request.User.UserName,
                Password = request.User.Password
            };

            _database.Users.Add(newUser);

            return Task.FromResult(true);
        }
    }
}

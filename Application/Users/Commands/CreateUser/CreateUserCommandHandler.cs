using Domain.Models;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly FakeDatabase _database;

        public CreateUserCommandHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User newUser = new()
            {
                Id = _database.Users.Max(u => u.Id) + 1,
                UserName = request.user.UserName,
                Password = request.user.Password
            };

            _database.Users.Add(newUser);

            return Task.FromResult(true);
        }
    }
}

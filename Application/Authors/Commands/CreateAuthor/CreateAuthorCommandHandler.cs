using Domain.Models;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, bool>
    {
        private readonly FakeDatabase _database;

        public CreateAuthorCommandHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<bool> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.author.Name))
                return Task.FromResult(false);

            var newAuthor = new Author
            {
                Id = _database.Authors.Max(x => x.Id) + 1,
                Name = request.author.Name
            };

            _database.Authors.Add(newAuthor);
            
            return Task.FromResult(true);
        }
    }
}

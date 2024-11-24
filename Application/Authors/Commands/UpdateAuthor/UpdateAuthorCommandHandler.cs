using Domain.Models;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, bool>
    {
        private readonly FakeDatabase _database;

        public UpdateAuthorCommandHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author author = _database.Authors.FirstOrDefault(a => a.Id == request.id)!;

            if (author == null)
                return Task.FromResult(false);

            if (string.IsNullOrEmpty(request.author.Name))
                return Task.FromResult(false);

            if (!_database.Authors.Exists(a => a.Id == request.id))
                return Task.FromResult(false);

            author.Name = request.author.Name;
            return Task.FromResult(true);
        }
    }
}

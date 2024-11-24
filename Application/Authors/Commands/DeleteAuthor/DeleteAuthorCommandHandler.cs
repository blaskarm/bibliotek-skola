using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly FakeDatabase _database;

        public DeleteAuthorCommandHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            int index = _database.Authors.FindIndex(a => a.Id == request.id);

            if (index < 0)
                return Task.FromResult(false);

            _database.Authors.RemoveAt(index);

            return Task.FromResult(true);
        }
    }
}

using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler(IFakeDatabase database) : IRequestHandler<UpdateAuthorCommand, bool>
    {
        private readonly IFakeDatabase _database = database;

        public Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author author = _database.Authors.FirstOrDefault(a => a.Id == request.Id)!;

            if (author == null)
                return Task.FromResult(false);

            if (string.IsNullOrEmpty(request.Author.Name))
                return Task.FromResult(false);

            if (!_database.Authors.Exists(a => a.Id == request.Id))
                return Task.FromResult(false);

            author.Name = request.Author.Name;
            return Task.FromResult(true);
        }
    }
}

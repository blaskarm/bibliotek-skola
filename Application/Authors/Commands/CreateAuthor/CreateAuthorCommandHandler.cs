using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler(IFakeDatabase database) : IRequestHandler<CreateAuthorCommand, bool>
    {
        private readonly IFakeDatabase _database = database;

        public Task<bool> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Author.Name))
                return Task.FromResult(false);

            var newAuthor = new Author
            {
                Id = _database.Authors.Max(x => x.Id) + 1,
                Name = request.Author.Name
            };

            _database.Authors.Add(newAuthor);
            
            return Task.FromResult(true);
        }
    }
}

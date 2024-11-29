using Application.Interfaces;
using MediatR;

namespace Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler(IFakeDatabase database) : IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly IFakeDatabase _database = database;

        public Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            int index = _database.Authors.FindIndex(a => a.Id == request.Id);

            if (index < 0)
                return Task.FromResult(false);

            _database.Authors.RemoveAt(index);

            return Task.FromResult(true);
        }
    }
}

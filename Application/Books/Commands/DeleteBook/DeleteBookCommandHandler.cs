using Application.Interfaces;
using MediatR;

namespace Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler(IFakeDatabase database) : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IFakeDatabase _database = database;

        public Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            int index = _database.Books.FindIndex(x => x.Id == request.Id);

            if (index < 0)
                return Task.FromResult(false);

            _database.Books.RemoveAt(index);

            return Task.FromResult(true);
        }
    }
}

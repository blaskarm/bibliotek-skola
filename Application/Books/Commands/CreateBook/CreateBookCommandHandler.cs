using Domain.Models;
using Infrastructure.Data;
using MediatR;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, bool>
    {
        private readonly FakeDatabase _database;

        public CreateBookCommandHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<bool> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(command.book.Title) || 
                !_database.Authors.Exists(x => x.Id == command.book.AuthorId))
                return Task.FromResult(false);

            Book book = new()
            {
                Id = _database.Books.Max(x => x.Id) + 1,
                Title = command.book.Title,
                AuthorId = command.book.AuthorId
            };
            _database.Books.Add(book);

            return Task.FromResult(true);
        }
    }
}

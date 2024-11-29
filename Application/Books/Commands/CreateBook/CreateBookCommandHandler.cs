using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler(IFakeDatabase database) : IRequestHandler<CreateBookCommand, bool>
    {
        private readonly IFakeDatabase _database = database;

        public async Task<bool> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(command.Book.Title) ||
                !_database.Authors.Exists(x => x.Id == command.Book.AuthorId))
                return await Task.FromResult(false);

            Book book = new()
            {
                Id = _database.Books.Max(x => x.Id) + 1,
                Title = command.Book.Title,
                AuthorId = command.Book.AuthorId
            };

            _database.Books.Add(book);

            return await Task.FromResult(true);
        }
    }
}

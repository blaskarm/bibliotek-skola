using Domain.Models;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly FakeDatabase _database;

        public CreateBookCommandHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<Book> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(command.book.Title))
            {
                throw new ArgumentException("Title cannot be empty.");
            }

            if (!_database.Authors.Exists(x => x.Id == command.book.AuthorId))
            {
                throw new ArgumentException("Author does not exists.");
            }

            Book book = new()
            {
                Id = command.book.Id = _database.Books.Max(x => x.Id) + 1,
                Title = command.book.Title,
                AuthorId = command.book.AuthorId
            };

            _database.Books.Add(book);
            return Task.FromResult(book);
        }
    }
}

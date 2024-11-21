using Domain.Models;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CreateBook
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
            _database.Books.Add(command.Book);
            return Task.FromResult(command.Book);
        }
    }
}

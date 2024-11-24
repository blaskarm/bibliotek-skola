using Domain.Models;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly FakeDatabase _database;

        public UpdateBookCommandHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = _database.Books.FirstOrDefault(b => b.Id == request.id)!;

            if (book == null)
                return Task.FromResult(false);

            if (string.IsNullOrEmpty(request.book.Title))
                return Task.FromResult(false);

            if (!_database.Authors.Exists(a => a.Id == request.book.AuthorId))
                return Task.FromResult(false);

            book.Title = request.book.Title;
            book.AuthorId = request.book.AuthorId;
            
            return Task.FromResult(true);
        }
    }
}

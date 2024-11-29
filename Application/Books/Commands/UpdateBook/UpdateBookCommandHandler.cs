using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler(IFakeDatabase database) : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly IFakeDatabase _database = database;

        public Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = _database.Books.FirstOrDefault(b => b.Id == request.Id)!;

            if (book == null)
                return Task.FromResult(false);

            if (string.IsNullOrEmpty(request.Book.Title))
                return Task.FromResult(false);

            if (!_database.Authors.Exists(a => a.Id == request.Book.AuthorId))
                return Task.FromResult(false);

            book.Title = request.Book.Title;
            book.AuthorId = request.Book.AuthorId;
            
            return Task.FromResult(true);
        }
    }
}

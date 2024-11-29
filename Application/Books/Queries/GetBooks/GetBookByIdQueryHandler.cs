using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Books.Queries.GetBooks
{
    public class GetBookByIdQueryHandler(IFakeDatabase database) : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IFakeDatabase _database = database;

        public Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            Book book = _database.Books.FirstOrDefault(b => b.Id == request.Id)!;
            return Task.FromResult(book);
        }
    }
}

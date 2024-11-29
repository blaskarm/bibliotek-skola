using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Books.Queries.GetBooks
{
    public class GetAllBooksQueryHandler(IFakeDatabase database) : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private readonly IFakeDatabase _database = database;
        //private readonly IBookRepository _repository = repository;

        public Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            List<Book> books = _database.Books;
            return Task.FromResult(books);
        }
    }
}

using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Books.Queries.GetBooks
{
    public class GetAllBooksQueryHandler(IBookRepository repository) : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private readonly IBookRepository _repository = repository;

        public async Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Book> books = await _repository.GetAllAsync();
            return books.ToList();
        }
    }
}

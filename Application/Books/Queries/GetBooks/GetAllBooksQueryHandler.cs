using Application.Interfaces;
using Application.Utilities;
using Domain.Models;
using MediatR;

namespace Application.Books.Queries.GetBooks
{
    public class GetAllBooksQueryHandler(IBookRepository repository) : IRequestHandler<GetAllBooksQuery, Result<List<Book>>>
    {
        private readonly IBookRepository _repository = repository;

        public async Task<Result<List<Book>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Book> books = await _repository.GetAllAsync();
                return Result<List<Book>>.Success(books.ToList());
            }
            catch
            {
                return Result<List<Book>>.Failure("Something went wrong");
            }
        }
    }
}

using Application.Interfaces;
using Application.Utilities;
using Domain.Models;
using MediatR;

namespace Application.Books.Queries.GetBooks
{
    public class GetBookByIdQueryHandler(IBookRepository repository) : IRequestHandler<GetBookByIdQuery, Result<Book>>
    {
        private readonly IBookRepository _repository = repository;

        public async Task<Result<Book>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            Book book = await _repository.GetByIdAsync(request.Id);
            return book is null ? Result<Book>.Failure("Book not found") : Result<Book>.Success(book);
        }
    }
}

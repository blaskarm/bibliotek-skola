using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Books.Queries.GetBooks
{
    public class GetBookByIdQueryHandler(IBookRepository repository) : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IBookRepository _repository = repository;

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            Book book = await _repository.GetByIdAsync(request.Id);
            return book is not null ? book : null!;
        }
    }
}

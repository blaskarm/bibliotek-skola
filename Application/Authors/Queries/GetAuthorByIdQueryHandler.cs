using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Authors.Queries
{
    public class GetAuthorByIdQueryHandler(IFakeDatabase database, IAuthorRepository repository) : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly IFakeDatabase _database = database;
        private readonly IAuthorRepository _repository = repository;

        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            Author author = await _repository.GetByIdAsync(request.Id);

            if (author is null)
                return null!;

            return author;
        }
    }
}

using Application.Interfaces;
using Application.Utilities;
using Domain.Models;
using MediatR;

namespace Application.Authors.Queries
{
    public class GetAuthorByIdQueryHandler(IAuthorRepository repository) : IRequestHandler<GetAuthorByIdQuery, Result<Author>>
    {
        private readonly IAuthorRepository _repository = repository;

        public async Task<Result<Author>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            Author author = await _repository.GetByIdAsync(request.Id);

            if (author is null)
                return Result<Author>.Failure("Author not found");

            return Result<Author>.Success(author);
        }
    }
}

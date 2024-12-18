using Application.Interfaces;
using Application.Utilities;
using Domain.Models;
using MediatR;

namespace Application.Authors.Queries
{
    public class GetAllAuthorsQueryHandler(IAuthorRepository repository) : IRequestHandler<GetAllAuthorsQuery, Result<List<Author>>>
    {
        private readonly IAuthorRepository _repository = repository;

        public async Task<Result<List<Author>>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Author> authors = await _repository.GetAllAsync();
                return Result<List<Author>>.Success(authors.ToList());
            }
            catch
            {
                return Result<List<Author>>.Failure("Something went wrong");
            }
        }
    }
}

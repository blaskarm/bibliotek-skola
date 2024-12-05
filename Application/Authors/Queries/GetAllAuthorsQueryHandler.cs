using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Authors.Queries
{
    public class GetAllAuthorsQueryHandler(IAuthorRepository repository) : IRequestHandler<GetAllAuthorsQuery, List<Author>>
    {
        private readonly IAuthorRepository _repository = repository;

        public async Task<List<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Author> authors = await _repository.GetAllAsync();
            return authors.ToList();
        }
    }
}

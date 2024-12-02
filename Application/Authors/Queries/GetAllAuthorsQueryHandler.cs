using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Authors.Queries
{
    public class GetAllAuthorsQueryHandler(IRepository<Author> repository) : IRequestHandler<GetAllAuthorsQuery, List<Author>>
    {
        private readonly IRepository<Author> _repository = repository;

        public async Task<List<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Author> authors = await _repository.GetAllAsync();
            return authors.ToList();
        }
    }
}

using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Authors.Queries
{
    public class GetAllAuthorsQueryHandler(IFakeDatabase database) : IRequestHandler<GetAllAuthorsQuery, List<Author>>
    {
        private readonly IFakeDatabase _database = database;

        public Task<List<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            List<Author> authors = _database.Authors;
            return Task.FromResult(authors);
        }
    }
}

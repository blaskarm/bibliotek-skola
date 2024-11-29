using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Authors.Queries
{
    public class GetAuthorByIdQueryHandler(IFakeDatabase database) : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly IFakeDatabase _database = database;

        public Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            Author author = _database.Authors.FirstOrDefault(a => a.Id == request.Id)!;
            return Task.FromResult(author);
        }
    }
}

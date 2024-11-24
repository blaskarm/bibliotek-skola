using Domain.Models;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Queries
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly FakeDatabase _database;

        public GetAuthorByIdQueryHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            Author author = _database.Authors.FirstOrDefault(a => a.Id == request.id)!;
            return Task.FromResult(author);
        }
    }
}

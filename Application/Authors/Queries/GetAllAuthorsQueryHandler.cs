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
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<Author>>
    {
        private readonly FakeDatabase _database;

        public GetAllAuthorsQueryHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<List<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            List<Author> authors = _database.Authors;
            return Task.FromResult(authors);
        }
    }
}

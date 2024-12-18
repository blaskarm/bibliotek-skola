using Application.Utilities;
using Domain.Models;
using MediatR;

namespace Application.Authors.Queries
{
    public record GetAllAuthorsQuery : IRequest<Result<List<Author>>>;
}

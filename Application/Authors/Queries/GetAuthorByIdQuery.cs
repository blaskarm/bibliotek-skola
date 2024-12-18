using Application.Utilities;
using Domain.Models;
using MediatR;

namespace Application.Authors.Queries
{
    public record GetAuthorByIdQuery(int Id) : IRequest<Result<Author>>;
}

using Application.Utilities;
using Domain.Models;
using MediatR;

namespace Application.Books.Queries.GetBooks
{
    public record GetBookByIdQuery(int Id) : IRequest<Result<Book>>;
}

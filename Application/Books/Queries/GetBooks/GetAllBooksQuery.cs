using Domain.Models;
using MediatR;

namespace Application.Books.Queries.GetBooks
{
    public record GetAllBooksQuery : IRequest<List<Book>>;
}

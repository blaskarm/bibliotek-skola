using Application.Dtos;
using MediatR;

namespace Application.Books.Commands.CreateBook
{
    public record CreateBookCommand(BookDto Book) : IRequest<bool>;
}

using Application.Dtos;
using Application.Utilities;
using MediatR;

namespace Application.Books.Commands.CreateBook
{
    public record CreateBookCommand(BookDto Book) : IRequest<Result<BookDto>>;
}

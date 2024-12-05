using Application.Dtos;
using Application.Utilities;
using MediatR;

namespace Application.Books.Commands.UpdateBook
{
    public record UpdateBookCommand(int Id, BookDto Book) : IRequest<Result<BookDto>>;
}

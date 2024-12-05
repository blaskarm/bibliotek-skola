using Application.Dtos;
using Application.Utilities;
using MediatR;

namespace Application.Books.Commands.DeleteBook
{
    public record DeleteBookCommand(int Id) : IRequest<Result<BookDto>>;
}

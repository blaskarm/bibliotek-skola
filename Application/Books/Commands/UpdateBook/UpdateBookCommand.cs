using Application.Dtos;
using MediatR;

namespace Application.Books.Commands.UpdateBook
{
    public record UpdateBookCommand(int Id, BookDto Book) : IRequest<bool>;
}

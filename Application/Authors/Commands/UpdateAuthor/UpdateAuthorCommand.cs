using Application.Dtos;
using MediatR;

namespace Application.Authors.Commands.UpdateAuthor
{
    public record UpdateAuthorCommand(int Id, AuthorDto Author) : IRequest<bool>;
}

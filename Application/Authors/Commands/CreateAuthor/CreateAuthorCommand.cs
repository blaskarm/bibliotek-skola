using Application.Dtos;
using MediatR;

namespace Application.Authors.Commands.CreateAuthor
{
    public record CreateAuthorCommand(AuthorDto Author) : IRequest<bool>;
}

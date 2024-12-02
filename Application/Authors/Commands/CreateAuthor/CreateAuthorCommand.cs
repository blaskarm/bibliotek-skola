using Application.Dtos;
using Application.Utilities;
using MediatR;

namespace Application.Authors.Commands.CreateAuthor
{
    public record CreateAuthorCommand(AuthorDto Author) : IRequest<Result<AuthorDto>>;
}

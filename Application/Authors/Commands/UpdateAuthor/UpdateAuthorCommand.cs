using Application.Dtos;
using Application.Utilities;
using MediatR;

namespace Application.Authors.Commands.UpdateAuthor
{
    public record UpdateAuthorCommand(int Id, AuthorDto Author) : IRequest<Result<AuthorDto>>;
}

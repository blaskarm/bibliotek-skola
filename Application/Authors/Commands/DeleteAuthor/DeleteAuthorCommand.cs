using Application.Dtos;
using Application.Utilities;
using MediatR;

namespace Application.Authors.Commands.DeleteAuthor
{
    public record DeleteAuthorCommand(int Id) : IRequest<Result<AuthorDto>>;
}

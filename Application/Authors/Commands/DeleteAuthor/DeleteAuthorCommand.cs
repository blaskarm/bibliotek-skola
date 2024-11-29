using MediatR;

namespace Application.Authors.Commands.DeleteAuthor
{
    public record DeleteAuthorCommand(int Id) : IRequest<bool>;
}

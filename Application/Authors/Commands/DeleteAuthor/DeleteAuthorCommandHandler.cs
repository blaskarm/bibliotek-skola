using Application.Dtos;
using Application.Interfaces;
using Application.Utilities;
using MediatR;

namespace Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler(IAuthorRepository repository) : IRequestHandler<DeleteAuthorCommand, Result<AuthorDto>>
    {
        private readonly IAuthorRepository _repository = repository;

        public async Task<Result<AuthorDto>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            bool success = await _repository.DeleteAsync(request.Id);

            if (!success)
                return Result<AuthorDto>.Failure("Author not found");

            return Result<AuthorDto>.Success(null!, "Successfully deleted author");
        }
    }
}

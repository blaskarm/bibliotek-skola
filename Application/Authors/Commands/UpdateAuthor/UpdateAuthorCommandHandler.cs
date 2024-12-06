using Application.Dtos;
using Application.Interfaces;
using Application.Utilities;
using Domain.Models;
using MediatR;

namespace Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler(IAuthorRepository repository) : IRequestHandler<UpdateAuthorCommand, Result<AuthorDto>>
    {
        private readonly IAuthorRepository _repository = repository;

        public async Task<Result<AuthorDto>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author author = await _repository.GetByIdAsync(request.Id);

            if (author is null)
                return Result<AuthorDto>.Failure("Author does not exists.");

            if (string.IsNullOrEmpty(request.Author.Name))
                return Result<AuthorDto>.Failure("Author name cannot be null or empty.");

            
            author.Name = request.Author.Name;
            await _repository.UpdateAsync(author);

            return Result<AuthorDto>.Success(request.Author, "Author successfully updated.");
        }
    }
}

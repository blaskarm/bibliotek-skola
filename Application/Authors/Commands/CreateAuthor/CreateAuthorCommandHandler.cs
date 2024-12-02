using Application.Dtos;
using Application.Interfaces;
using Application.Utilities;
using Domain.Models;
using MediatR;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler(IAuthorRepository repository) : IRequestHandler<CreateAuthorCommand, Result<AuthorDto>>
    {
        private readonly IAuthorRepository _repository = repository;

        public async Task<Result<AuthorDto>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Author.Name))
                return Result<AuthorDto>.Failure("Author name cannot be null or empty");

            if (await _repository.AuthorExists(request.Author.Name))
                return Result<AuthorDto>.Failure("Author already exists");

            var newAuthor = new Author
            {
                Name = request.Author.Name
            };

            await _repository.AddAsync(newAuthor);

            return Result<AuthorDto>.Success(request.Author, "Author successfully added to database");
        }
    }
}

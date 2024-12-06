using Application.Dtos;
using Application.Interfaces;
using Application.Utilities;
using MediatR;

namespace Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler(IFakeDatabase database, IBookRepository repository) : IRequestHandler<DeleteBookCommand, Result<BookDto>>
    {
        private readonly IFakeDatabase _database = database;
        private readonly IBookRepository _repository = repository;

        public async Task<Result<BookDto>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            if (!await _repository.DeleteAsync(request.Id))
                return Result<BookDto>.Failure("Book not found");

            return Result<BookDto>.Success(null!, "Book successfully deleted");
        }
    }
}

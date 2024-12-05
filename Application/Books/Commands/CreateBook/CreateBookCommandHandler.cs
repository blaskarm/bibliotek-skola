using Application.Dtos;
using Application.Interfaces;
using Application.Utilities;
using Domain.Models;
using MediatR;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler(IBookRepository bookRepository, IAuthorRepository authorRepository) : IRequestHandler<CreateBookCommand, Result<BookDto>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IAuthorRepository _authorRepository = authorRepository;

        public async Task<Result<BookDto>> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            if (await _authorRepository.FindAsync(command.Book.AuthorId) is null)
                return Result<BookDto>.Failure("The author id does not exists in the database");

            if (await _bookRepository.BookTitleExists(command.Book.Title))
                return Result<BookDto>.Failure("The book title already exists in the database");

            Book book = new()
            {
                Title = command.Book.Title,
                AuthorId = command.Book.AuthorId
            };

            await _bookRepository.AddAsync(book);

            return Result<BookDto>.Success(command.Book, "Book successfully added to the database");
        }
    }
}

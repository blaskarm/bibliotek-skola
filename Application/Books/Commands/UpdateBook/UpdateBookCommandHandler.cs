using Application.Dtos;
using Application.Interfaces;
using Application.Utilities;
using Domain.Models;
using MediatR;

namespace Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler(IBookRepository bookRepository, IAuthorRepository authorRepository) : IRequestHandler<UpdateBookCommand, Result<BookDto>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IAuthorRepository _authorRepository = authorRepository;

        public async Task<Result<BookDto>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = await _bookRepository.GetByIdAsync(request.Id);

            if (book is null)
                return Result<BookDto>.Failure("Book does not exists");

            if (string.IsNullOrEmpty(request.Book.Title))
                return Result<BookDto>.Failure("Title cannot be empty");

            if (await _authorRepository.GetByIdAsync(request.Book.AuthorId) is null)
                return Result<BookDto>.Failure("The author id does not exists in the database");

            if (await _bookRepository.BookTitleExists(request.Book.Title))
                return Result<BookDto>.Failure("The book title already exists in the database");

            book.Title = request.Book.Title;
            book.AuthorId = request.Book.AuthorId;

            await _bookRepository.UpdateAsync(request.Id, book);

            return Result<BookDto>.Success(request.Book, "Successfully updated book in database");
        }
    }
}

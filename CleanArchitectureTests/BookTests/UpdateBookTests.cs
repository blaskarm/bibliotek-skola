using Application.Books.Commands.UpdateBook;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Data;

namespace CleanArchitectureTests.BookTests
{
    public class UpdateBookTests
    {
        private readonly FakeDatabase _database;
        private readonly UpdateBookCommandHandler _commandHandler;
        private readonly CancellationToken _cancellationToken;

        public UpdateBookTests()
        {
            _database = new FakeDatabase();
            _commandHandler = new UpdateBookCommandHandler(_database);
            _cancellationToken = CancellationToken.None;
        }

        [Fact]
        public async Task ShouldUpdateTitleAndAuthorId_ReturnsTrue()
        {
            // Arrange
            int id = 1;
            var testBook = new BookDto
            {
                Title = "New Title",
                AuthorId = 3
            };
            var request = new UpdateBookCommand(id, testBook);

            // Act
            bool result = await _commandHandler.Handle(request, _cancellationToken);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Handle_EmptyTitle_ReturnsFalse()
        {
            // Arrange
            int id = 1;
            var testBook = new BookDto
            {
                Title = "",
                AuthorId = 1
            };
            var request = new UpdateBookCommand(id, testBook);

            // Act
            bool result = await _commandHandler.Handle(request, _cancellationToken);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Handle_AuthorDontExists_ReturnsFalse()
        {
            // Arrange
            int id = 1;
            var testBook = new BookDto
            {
                Title = "New Title",
                AuthorId = 0
            };
            var request = new UpdateBookCommand(id, testBook);

            // Act
            bool result = await _commandHandler.Handle(request, _cancellationToken);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Handle_BookIdDontExists_ReturnsFalse()
        {
            // Arrange
            int id = 0;
            var testBook = new BookDto
            {
                Title = "New Title",
                AuthorId = 1
            };
            var request = new UpdateBookCommand(id, testBook);

            // Act
            bool result = await _commandHandler.Handle(request, _cancellationToken);

            // Assert
            Assert.False(result);
        }
    }
}

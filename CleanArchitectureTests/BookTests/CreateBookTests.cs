using Application.Books.Commands.CreateBook;
using Application.Dtos;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTests.BookTests
{
    public class CreateBookTests
    {
        private readonly FakeDatabase _database;
        private readonly CreateBookCommandHandler _commandHandler;
        private readonly CancellationToken _cancellationToken;

        public CreateBookTests()
        {
            _database = new FakeDatabase();
            _commandHandler = new CreateBookCommandHandler(_database);
            _cancellationToken = CancellationToken.None;
        }

        [Fact]
        public async Task ShouldCreateBookInDatabase_ReturnsTrue()
        {
            // Arrange
            int expectedLengthOfDatabase = _database.Books.Count + 1;
            var testBook = new BookDto
            {
                Title = "Test Book",
                AuthorId = 1
            };
            var command = new CreateBookCommand(testBook);


            // Act
            bool result = await _commandHandler.Handle(command, _cancellationToken);

            // Assert
            Assert.True(result);
            Assert.Equal(expectedLengthOfDatabase, _database.Books.Count);
        }

        [Fact]
        public async Task Handle_EmptyTitle_ReturnFalse()
        {
            // Arrange
            var testBook = new BookDto
            {
                Title = "",
                AuthorId = 1
            };
            var command = new CreateBookCommand(testBook);

            // Act
            bool result = await _commandHandler.Handle(command, _cancellationToken);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Handle_AuthorNotExists_ReturnFalse()
        {
            // Arrange
            var testBook = new BookDto
            {
                Title = "Test book",
                AuthorId = 0
            };
            var command = new CreateBookCommand(testBook);

            // Act
            bool result = await _commandHandler.Handle(command, _cancellationToken);

            // Assert
            Assert.False(result);
        }
    }
}

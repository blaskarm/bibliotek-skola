using Application.Books.Commands.DeleteBook;
using Infrastructure.Data;

namespace CleanArchitectureTests.BookTests
{
    public class DeleteBookTests
    {
        private readonly FakeDatabase _database;
        private readonly DeleteBookCommandHandler _commandHandler;

        public DeleteBookTests()
        {
            _database = new FakeDatabase();
            _commandHandler = new DeleteBookCommandHandler(_database);
        }

        [Fact]
        public async Task ShouldDeleteBookFromDatabase_ReturnsTrue()
        {
            // Arrange
            int id = 1;
            int expectedLengthOfDatabase = _database.Books.Count - 1;
            var request = new DeleteBookCommand(id);

            // Act
            bool result = await _commandHandler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result);
            Assert.Equal(expectedLengthOfDatabase, _database.Books.Count);
        }

        [Fact]
        public async Task Handle_BookIdDontExists_ReturnsFalse()
        {
            // Arrange
            int id = 0;
            var request = new DeleteBookCommand(id);

            // Act
            bool result = await _commandHandler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result);
        }
    }
}

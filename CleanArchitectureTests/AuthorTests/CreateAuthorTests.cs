using Application.Authors.Commands.CreateAuthor;
using Application.Dtos;
using Infrastructure.Data;

namespace CleanArchitectureTests.AuthorTests
{
    public class CreateAuthorTests
    {
        private readonly FakeDatabase _database;
        private readonly CreateAuthorCommandHandler _commandHandler;
        private readonly CancellationToken _cancellationToken;

        public CreateAuthorTests()
        {
            _database = new FakeDatabase();
            _commandHandler = new CreateAuthorCommandHandler(_database);
            _cancellationToken = CancellationToken.None;
        }

        [Fact]
        public async Task ShouldCreateAuthorInDatabase_ReturnTrue()
        {
            // Arrange
            var author = new AuthorDto
            {
                Name = "Test Author"
            };
            var request = new CreateAuthorCommand(author);
            int expectedLengthOfList = _database.Authors.Count + 1;

            // Act
            bool result = await _commandHandler.Handle(request, _cancellationToken);

            // Assert
            Assert.True(result);
            Assert.Equal(expectedLengthOfList, _database.Authors.Count);
        }

        [Fact]
        public async Task Handle_EmptyName_ReturnFalse()
        {
            // Arrange
            var author = new AuthorDto
            {
                Name = ""
            };
            var request = new CreateAuthorCommand(author);

            // Act
            bool result = await _commandHandler.Handle(request, _cancellationToken);

            // Assert
            Assert.False(result);
        }
    }
}

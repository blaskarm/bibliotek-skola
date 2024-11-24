using Application.Authors.Commands.UpdateAuthor;
using Application.Dtos;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTests.AuthorTests
{
    public class UpdateAuthorTests
    {
        private readonly FakeDatabase _database;
        private readonly UpdateAuthorCommandHandler _commandHandler;
        private readonly CancellationToken _cancellationToken;

        public UpdateAuthorTests()
        {
            _database = new FakeDatabase();
            _commandHandler = new UpdateAuthorCommandHandler(_database);
            _cancellationToken = CancellationToken.None;
        }

        [Fact]
        public async Task ShouldUpdateAuthorInDatabase_ReturnTrue()
        {
            // Arrange
            int id = 1;
            var author = new AuthorDto
            {
                Name = "New Name"
            };
            var request = new UpdateAuthorCommand(id, author);

            // Act
            bool result = await _commandHandler.Handle(request, _cancellationToken);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Handle_EmptyName_ReturnFalse()
        {
            // Arrange
            int id = 1;
            var author = new AuthorDto
            {
                Name = ""
            };
            var request = new UpdateAuthorCommand(id, author);

            // Act
            bool result = await _commandHandler.Handle(request, _cancellationToken);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Handle_AuthorNotExisting_ReturnFalse()
        {
            // Arrange
            int id = 0;
            var author = new AuthorDto
            {
                Name = "New Name"
            };
            var request = new UpdateAuthorCommand(id, author);

            // Act
            bool result = await _commandHandler.Handle(request, _cancellationToken);

            // Assert
            Assert.False(result);
        }
    }
}

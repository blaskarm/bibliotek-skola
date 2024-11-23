using Application.Books.Commands.DeleteBook;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var request = new DeleteBookCommand(id);

            // Act
            bool result = await _commandHandler.Handle(request, CancellationToken.None);
            bool deleted = _database.Books.Exists(b => b.Id == id);

            // Assert
            Assert.True(result);
            Assert.True(!deleted);
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
            Assert.True(!result);
        }
    }
}

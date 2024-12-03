//using Application.Authors.Commands.DeleteAuthor;
//using Infrastructure.Data;

//namespace CleanArchitectureTests.AuthorTests
//{
//    public class DeleteAuthorTests
//    {
//        private readonly FakeDatabase _database;
//        private readonly DeleteAuthorCommandHandler _commandHandler;

//        public DeleteAuthorTests()
//        {
//            _database = new FakeDatabase();
//            _commandHandler = new DeleteAuthorCommandHandler(_database);
//        }

//        [Fact]
//        public async Task ShouldDeleteAuthorFromDatabase_ReturnTrue()
//        {
//            // Arrange
//            int id = 1;
//            int expectedLengthOfList = _database.Authors.Count - 1;
//            var request = new DeleteAuthorCommand(id);

//            // Act
//            bool result = await _commandHandler.Handle(request, CancellationToken.None);

//            // Assert
//            Assert.True(result);
//            Assert.Equal(expectedLengthOfList, _database.Authors.Count);
//        }

//        [Fact]
//        public async Task Handle_AuthorIdNotExisting_ReturnFalse()
//        {
//            // Arrange
//            int id = 0;
//            var request = new DeleteAuthorCommand(id);

//            // Act
//            bool result = await _commandHandler.Handle(request, CancellationToken.None);

//            // Assert
//            Assert.False(result);
//        }
//    }
//}

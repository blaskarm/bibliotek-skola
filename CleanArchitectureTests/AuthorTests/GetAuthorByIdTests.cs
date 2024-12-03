//using Application.Authors.Queries;
//using Domain.Models;
//using Infrastructure.Data;

//namespace CleanArchitectureTests.AuthorTests
//{
//    public class GetAuthorByIdTests
//    {
//        private readonly FakeDatabase _database;
//        private readonly GetAuthorByIdQueryHandler _queryHandler;

//        public GetAuthorByIdTests()
//        {
//            _database = new FakeDatabase();
//            _queryHandler = new GetAuthorByIdQueryHandler(_database);
//        }

//        [Fact]
//        public async Task ShouldGetAuthorFromDatabase_ReturnsAuthor()
//        {
//            // Arrange
//            int id = 1;
//            var request = new GetAuthorByIdQuery(id);

//            // Act
//            Author author = await _queryHandler.Handle(request, CancellationToken.None);

//            // Assert
//            Assert.Equal(id, author.Id);
//        }

//        [Fact]
//        public async Task Handle_AuthorIdDontExists_ReturnsNull()
//        {
//            // Arrange
//            int id = 0;
//            var request = new GetAuthorByIdQuery(id);

//            // Act
//            Author author = await _queryHandler.Handle(request, CancellationToken.None);

//            // Assert
//            Assert.Null(author);
//        }
//    }
//}

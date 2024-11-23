using Application.Books.Queries.GetBooks;
using Domain.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTests.BookTests
{
    public class GetBookByIdTests
    {
        private readonly FakeDatabase _database;
        private readonly GetBookByIdQueryHandler _queryHandler;

        public GetBookByIdTests()
        {
            _database = new FakeDatabase();
            _queryHandler = new GetBookByIdQueryHandler(_database);
        }

        [Fact]
        public async Task ShouldGetBookFromDatabase_ReturnsBook()
        {
            // Arrange
            int id = 1;
            var request = new GetBookByIdQuery(id);

            // Act
            Book book = await _queryHandler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(id, book.Id);
        }

        [Fact]
        public async Task Handle_IdDontExists_ReturnsNull()
        {
            // Arrange
            int id = 0;
            var request = new GetBookByIdQuery(id);

            // Act
            Book book = await _queryHandler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(book);
        }
    }
}

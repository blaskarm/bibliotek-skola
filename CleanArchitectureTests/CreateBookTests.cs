﻿using Application.Books.Commands.CreateBook;
using Domain.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTests
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
        public void ShouldCreateBookInDatabase_ReturnsBook()
        {
            // Arrange
            var testBook = new Book 
            { 
                Title = "Test Book",
                AuthorId = 1 
            };
            var command = new CreateBookCommand(testBook);
            

            // Act
            _commandHandler.Handle(command, _cancellationToken);
            var actualBook = _database.Books.FirstOrDefault(x => x.Id == testBook.Id);

            // Assert
            Assert.Equal(testBook.Id, actualBook.Id);
            Assert.Equal(testBook.Title, actualBook.Title);
            Assert.Equal(testBook.AuthorId, actualBook.AuthorId);
        }
    }
}

using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class FakeDatabase
    {
        private List<Book> books =
        [
            new() { Id = 1, Title = "Book1", AuthorId = 1 },
            new() { Id = 2, Title = "Book2", AuthorId = 2 },
            new() { Id = 3, Title = "Book3", AuthorId = 1 },
            new() { Id = 4, Title = "Book4", AuthorId = 3 },
            new() { Id = 5, Title = "Book5", AuthorId = 3 }
        ];
        public List<Book> Books
        {
            get { return books; }
            set { books = value; }
        }


        private List<Author> authors =
        [
            new() { Id = 1, Name = "Author1" },
            new() { Id = 2, Name = "Author2" },
            new() { Id = 3, Name = "Author3" }
        ];
        public List<Author> Authors
        {
            get { return authors; }
            set { authors = value; }
        }


        private List<User> users =
        [
            new() { Id = 1, UserName = "User1", Password = "Password1" },
            new() { Id = 2, UserName = "User2", Password = "Password2" },
            new() { Id = 3, UserName = "User3", Password = "Password3" }
        ];
        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }
    }
}

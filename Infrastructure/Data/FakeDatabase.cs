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
        private List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Book1", AuthorId = 1 },
            new Book { Id = 2, Title = "Book2", AuthorId = 2 },
            new Book { Id = 3, Title = "Book3", AuthorId = 1 },
            new Book { Id = 4, Title = "Book4", AuthorId = 3 },
            new Book { Id = 5, Title = "Book5", AuthorId = 3 }
        };
        public List<Book> Books
        {
            get { return books; }
            set { books = value; }
        }

        private List<Author> authors = new List<Author>
        {
            new Author { Id = 1, Name = "Author1" },
            new Author { Id = 2, Name = "Author2" },
            new Author { Id = 3, Name = "Author3" }
        };
        public List<Author> Authors
        {
            get { return authors; }
            set { authors = value; }
        }
    }
}

using Domain.Models;

namespace Application.Interfaces
{
    public interface IFakeDatabase
    {
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }
        public List<User> Users { get; set; }
    }
}

using Domain.Models;

namespace Application.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> LoginUser(string username, string password);
        Task<bool> UserExists(string username);
    }
}

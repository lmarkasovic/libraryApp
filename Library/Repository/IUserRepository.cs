using Library.Models;

namespace Library.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserDetails(int id);
    }
}

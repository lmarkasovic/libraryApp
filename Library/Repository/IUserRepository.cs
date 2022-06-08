using Library.Models.Entity;

namespace Library.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserDetails(int id);
    }
}

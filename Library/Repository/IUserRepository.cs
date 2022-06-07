using Library.Models;

namespace Library.Repository
{
    public interface IUserRepository
    {
        User GetUserDetails(int id);
    }
}

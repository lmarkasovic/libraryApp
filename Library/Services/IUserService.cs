using Library.Models.ViewModels;

namespace Library.Services
{
    public interface IUserService
    {
        UserViewModel GetUserDetails(int id);
    }
}

using Library.Models.ViewModels;

namespace Library.Services
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserDetails(int id);
    }
}

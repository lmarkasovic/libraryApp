using Library.Models.DTO;

namespace Library.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUserDetails(int id);
    }
}

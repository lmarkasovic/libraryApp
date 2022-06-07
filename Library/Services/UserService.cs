using Library.Models.DTO;
using Library.Repository;

namespace Library.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserDTO> GetUserDetails(int id)
        {
            var user = await _userRepo.GetUserDetails(id);
            var result = new UserDTO()
            {
                Name = user.Name,
                Surname = user.Surname
            };
            return result;
        }
    }
}

using Library.DAL;
using Library.Models.Entity;

namespace Library.Repository
{
    public class UserRepository : IUserRepository
    {
        private LibraryContext _context;

        public UserRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserDetails(int id)
        {
            var user = await _context.Users.FindAsync(id);
            var result = new User()
            {
                Name = user.Name,
                Surname = user.Surname,
            };

            return result;
        }
    }
}

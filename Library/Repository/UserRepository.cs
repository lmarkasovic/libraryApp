using Library.DAL;
using Library.Models;

namespace Library.Repository
{
    public class UserRepository : IUserRepository
    {
        private LibraryContext _context;

        public UserRepository(LibraryContext context)
        {
            _context = context;

            //_context.SaveChanges();
        }

        public async Task<User> GetUserDetails(int id)
        {
            var user = new User()
            {
                Name = _context.Users.Where(a => a.Id == id).Select(x => x.Name).FirstOrDefault(),
                Surname = _context.Users.Where(a => a.Id == id).Select(x => x.Surname).FirstOrDefault()
            };

            return user;
        }
    }
}

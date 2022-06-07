using Library.Models.DTO;
using Library.Repository;

namespace Library.Services
{
    public class BookService: IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IUserRepository _userRepo;
        public BookService(IBookRepository bookRepo, IUserRepository userRepo)
        {
            _bookRepo = bookRepo;
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<BookDTO>> GetBooks()
        {
            var books = await _bookRepo.GetAllBooks();
            var result = new List<BookDTO>();
            foreach (var b in books)
            {
                UserDTO nameSurname = new UserDTO();
                if (b.BorrowerUserId != null)
                {
                    var userDetails = await _userRepo.GetUserDetails(b.BorrowerUserId.Value);
                    nameSurname = new UserDTO()
                    {
                        Name = userDetails.Name,
                        Surname = userDetails.Surname
                    };
                }
                BookDTO book = new BookDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    BorrowerUserId = b.BorrowerUserId,
                    BorrowerNameSurname = nameSurname.Name + ' ' + nameSurname.Surname
                };
                result.Add(book);
            }
            return result;
        }

        public async Task BorrowBook(string bookId, int userId)
        {
            var book = await _bookRepo.GetBookById(bookId);
            book.BorrowerUserId = userId;
            book.BorrowedUntil = DateTime.Now.AddDays(14);
            await _bookRepo.SaveBook(book);
        }

        public async Task ReturnBook(string bookId, int userId)
        {
            var book = await _bookRepo.GetBookById(bookId);
            book.BorrowerUserId = null;
            book.BorrowedUntil = null;
            await _bookRepo.SaveBook(book);
        }

        public async Task<BookDetailsDTO> GetBookDetails(string bookId)
        {
            var book = await _bookRepo.GetBookById(bookId);

            UserDTO nameSurname = new UserDTO();
            if (book.BorrowerUserId != null)
            {
                var user = await _userRepo.GetUserDetails(book.BorrowerUserId.Value);
                nameSurname = new UserDTO()
                {
                    Name = user.Name,
                    Surname = user.Surname
                };
            }

            var result = new BookDetailsDTO
            {
                Author = book.Author,
                Title = book.Title,
                Genre = book.Genre,
                Price = book.Price,
                PublishDate = book.PublishDate,
                Description = book.Description,
                Name = nameSurname.Name,
                Surname = nameSurname.Surname,
                BorrowedUntil = book.BorrowedUntil
            };
            return result;
        }
    }
}

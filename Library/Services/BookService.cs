using Library.Models;
using Library.Models.ViewModels;
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

        public async Task<IEnumerable<BookViewModel>> GetBooks()
        {
            var books = await _bookRepo.GetAllBooks();
            var result = new List<BookViewModel>();
            foreach (var b in books)
            {
                UserViewModel nameSurname = new UserViewModel();
                if (b.BorrowerUserId != null)
                {
                    var userDetails = await _userRepo.GetUserDetails(b.BorrowerUserId.Value);
                    nameSurname = new UserViewModel()
                    {
                        Name = userDetails.Name,
                        Surname = userDetails.Surname
                    };
                }
                BookViewModel book = new BookViewModel
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
            _bookRepo.SaveBook(book);
        }

        public async Task ReturnBook(string bookId, int userId)
        {
            var book = await _bookRepo.GetBookById(bookId);
            book.BorrowerUserId = null;
            book.BorrowedUntil = null;
            _bookRepo.SaveBook(book);
        }

        public async Task<BookDetailsViewModel> GetBookDetails(string bookId)
        {
            var book = await _bookRepo.GetBookById(bookId);

            UserViewModel nameSurname = new UserViewModel();
            if (book.BorrowerUserId != null)
            {
                var user = await _userRepo.GetUserDetails(book.BorrowerUserId.Value);
                nameSurname = new UserViewModel()
                {
                    Name = user.Name,
                    Surname = user.Surname
                };
            }

            var result = new BookDetailsViewModel
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

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

        public IEnumerable<BookViewModel> GetBooks()
        {
            var books = _bookRepo.GetAllBooks();
            var result = new List<BookViewModel>();
            foreach (var b in books)
            {
                UserViewModel nameSurname = new UserViewModel();
                if (b.BorrowerUserId != null)
                {
                    var userDetails = _userRepo.GetUserDetails(b.BorrowerUserId.Value);
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

        public void BorrowBook(string bookId, int userId)
        {
            var book = _bookRepo.GetBookById(bookId);
            book.BorrowerUserId = userId;          
            _bookRepo.SaveBook(book);
        }

        public void ReturnBook(string bookId, int userId)
        {
            var book = _bookRepo.GetBookById(bookId);
            book.BorrowerUserId = null;
            _bookRepo.SaveBook(book);
        }

        public BookDetailsViewModel GetBookDetails(string bookId)
        {
            var book = _bookRepo.GetBookById(bookId);

            UserViewModel nameSurname = new UserViewModel();
            if (book.BorrowerUserId != null)
            {
                var user = _userRepo.GetUserDetails(book.BorrowerUserId.Value);
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
                Surname = nameSurname.Surname
            };
            return result;
        }
    }
}

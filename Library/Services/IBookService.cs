using Library.Models.ViewModels;

namespace Library.Services
{
    public interface IBookService
    {
        IEnumerable<BookViewModel> GetBooks();
        void BorrowBook(string bookId, int userId);
        void ReturnBook(string bookId, int userId);
        BookDetailsViewModel GetBookDetails(string bookId);
    }
}

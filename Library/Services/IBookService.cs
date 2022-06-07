using Library.Models.ViewModels;

namespace Library.Services
{
    public interface IBookService
    {
        IEnumerable<BookViewModel> GetBooks();

        void BorrowBook(string BookId, int userId);
        void ReturnBook(string BookId, int userId);
    }
}

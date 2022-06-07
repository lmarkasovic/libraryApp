using Library.Models.ViewModels;

namespace Library.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetBooks();
        Task BorrowBook(string bookId, int userId);
        Task ReturnBook(string bookId, int userId);
        Task<BookDetailsViewModel> GetBookDetails(string bookId);
    }
}

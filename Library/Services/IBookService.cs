using Library.Models.DTO;
using Library.Models.ViewModels;

namespace Library.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetBooks();
        Task BorrowBook(string bookId, int userId);
        Task ReturnBook(string bookId, int userId);
        Task<BookDetailsDTO> GetBookDetails(string bookId);
    }
}

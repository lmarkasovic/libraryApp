using Library.Models.DTO;

namespace Library.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetBooks(int userId);
        Task BorrowBook(string bookId, int userId);
        Task ReturnBook(string bookId, int userId);
        Task<BookDetailsDTO> GetBookDetails(string bookId);
    }
}

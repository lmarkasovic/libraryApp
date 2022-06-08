using Library.Models.Entity;

namespace Library.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(string id);
        Task<Book> SaveBook(Book book);

    }
}

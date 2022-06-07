using Library.Models;

namespace Library.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(string id);
        Book SaveBook(Book book);

    }
}

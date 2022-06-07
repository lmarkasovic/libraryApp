using Library.Models;

namespace Library.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(string id);
        String GetBorrowerDetails(int id);
        Book SaveBook(Book book);

    }
}

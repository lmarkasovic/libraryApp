using Library.DAL;
using Library.Models.Entity;

namespace Library.Repository
{
    public class BookRepository : IBookRepository
    {
        private LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var books = new List<Book>();
            foreach (var item in _context.Catalog)
            {
                Book book = new Book
                {
                    Id = item.Id,
                    Title = item.Title,
                    Author = item.Author,
                    BorrowerUserId = item.BorrowerUserId
                };
                books.Add(book);
            }
            return books;
        }

        public async Task<Book> GetBookById(string id)
        {
            return _context.Catalog.Where(a => a.Id == id).FirstOrDefault();
        }

        public async Task<Book> SaveBook(Book book)
        {
            _context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return book;
        }
    }
}

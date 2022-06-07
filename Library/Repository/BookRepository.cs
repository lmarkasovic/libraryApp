using Library.DAL;
using Library.Models;
using System.Xml.Linq;

namespace Library.Repository
{
    public class BookRepository : IBookRepository
    {
        private LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
            if (!_context.Catalog.Any())
            {
                var result = from e in XDocument.Load("books.xml").Descendants("book")
                             select new
                             {
                                 Id = e.Attribute("id").Value,
                                 Author = e.Element("author").Value,
                                 Title = e.Element("title").Value,
                                 Genre = e.Element("genre").Value,
                                 Price = e.Element("price").Value,
                                 PublishDate = e.Element("publish_date").Value,
                                 Description = e.Element("description").Value
                             };
                foreach (var item in result)
                {
                    Book book = new Book
                    {
                        Id = item.Id,
                        Author = item.Author,
                        Title = item.Title,
                        Genre = item.Genre,
                        Price = item.Price,
                        PublishDate = DateTime.Parse(item.PublishDate),
                        Description = item.Description
                    };

                    _context.Catalog.Add(book);
                    _context.SaveChanges();
                }

                _context.Catalog.Where(a => a.Id == "bk111").FirstOrDefault().BorrowerUserId = 2;
                _context.Catalog.Where(a => a.Id == "bk111").FirstOrDefault().BorrowedUntil = DateTime.Now.AddDays(5);
                _context.Catalog.Where(a => a.Id == "bk108").FirstOrDefault().BorrowerUserId = 2;
                _context.Catalog.Where(a => a.Id == "bk108").FirstOrDefault().BorrowedUntil = DateTime.Now.AddDays(7);

                List<User> users = new List<User>()
                {
                    new User()
                    {
                        Id = 1,
                        Name = "John",
                        Surname = "Smith"
                    },
                    new User()
                    {
                        Id = 2,
                        Name = "Arthur",
                        Surname = "Morgan"
                    }
                };

                _context.Users.AddRange(users);
                _context.SaveChanges();
            }
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
            _context.SaveChanges();
            return book;
        }
    }
}

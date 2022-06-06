using Library.DAL;
using Library.Models;
using Library.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private LibraryContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(LibraryContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
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
                         PublishDate = item.PublishDate,
                         Description = item.Description
                     };

                    _context.Catalog.Add(book);
                    _context.SaveChanges();
                }

                _context.Catalog.Where(a => a.Id == "bk111").FirstOrDefault().BorrowerUserId = 2;
                User user = new User
                {
                    Id = 2,
                    Name = "Test",
                    Surname = "Testić"
                };
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        public IActionResult Index()
        {
            var books = new List<BookViewModel>();
            foreach (var item in _context.Catalog)
            {
                BookViewModel book = new BookViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Author = item.Author,
                    BorrowerUserId=item.BorrowerUserId,
                    BorrowerName = _context.Users.Where(a => a.Id == item.BorrowerUserId).Select(x => x.Name).FirstOrDefault(),
                    BorrowerSurname = _context.Users.Where(a => a.Id == item.BorrowerUserId).Select(x => x.Name).FirstOrDefault()
                };

                books.Add(book);
            }
            return View(books);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpPut]
        public IActionResult BorrowBookById(string BookId, int userId)
        {
            if (BookId == null)
                return BadRequest();

            Book book = _context.Catalog.Where(a => a.Id == BookId).FirstOrDefault();
            if (book == null)
                return NotFound();

            book.BorrowerUserId = userId;
            _context.SaveChanges();
            return new NoContentResult();
        }

        //[HttpPut]
        public IActionResult ReturnBookById(string BookId)
        {
            if (BookId == null)
                return BadRequest();

            Book book = _context.Catalog.Where(a => a.Id == BookId && a.BorrowerUserId!=null).FirstOrDefault();
            if (book == null)
                return NotFound();

            book.BorrowerUserId = null;
            _context.SaveChanges();
            return new NoContentResult();
        }

        public string GetUserById (int id)
        {
            User user = _context.Users.Where(a => a.Id == id).FirstOrDefault();
            return user.Name.ToString() + user.Surname.ToString();
        }
    }
}
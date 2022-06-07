using Library.DAL;
using Library.Models;
using Library.Models.ViewModels;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return View(_bookService.GetBooks());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpPut]
        public IActionResult BorrowBook(string BookId, int userId)
        {
            if (BookId == null)
                return BadRequest();

            _bookService.BorrowBook(BookId, userId);
            return RedirectToAction("Index");
        }

        public IActionResult ReturnBook(string BookId, int userId)
        {
            if (BookId == null)
                return BadRequest();

            _bookService.ReturnBook(BookId, userId);
            return RedirectToAction("Index");
        }

        //public IActionResult GetBookDetails(string BookId)
        //{
        //    var book = _context.Catalog.Where(a => a.Id == BookId).FirstOrDefault();
        //    BookDetailsViewModel result = new BookDetailsViewModel
        //    {
        //        Title = book.Title,
        //        Author = book.Author,
        //        Genre = book.Genre,
        //        Price = book.Price,
        //        PublishDate = book.PublishDate,
        //        Description = book.Description,
        //        BorrowerName = _context.Users.Where(a => a.Id == book.BorrowerUserId).Select(x => x.Name).FirstOrDefault(),
        //        BorrowerSurname = _context.Users.Where(a => a.Id == book.BorrowerUserId).Select(x => x.Surname).FirstOrDefault()
        //    };
        //    return View("Details", result);
        //}


    }
}
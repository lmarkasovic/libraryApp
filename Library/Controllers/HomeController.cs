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
        private readonly IUserService _userService;

        public HomeController(IBookService bookService, IUserService userService)
        {
            _bookService = bookService;
            _userService = userService;
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
        public IActionResult BorrowBook(string bookId, int userId)
        {
            if (bookId == null)
                return BadRequest();

            _bookService.BorrowBook(bookId, userId);
            return RedirectToAction("Index");
        }

        public IActionResult ReturnBook(string bookId, int userId)
        {
            if (bookId == null)
                return BadRequest();

            _bookService.ReturnBook(bookId, userId);
            return RedirectToAction("Index");
        }

        public IActionResult GetBookDetails(string bookId)
        {
            var result = _bookService.GetBookDetails(bookId);
            return View("Details", result);
        }

        public UserViewModel GetCurrentUser(int id)
        {
            return _userService.GetUserDetails(id);
        }
    }
}
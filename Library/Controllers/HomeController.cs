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

        public async Task<IActionResult> IndexAsync()
        {
            return View(await _bookService.GetBooks());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpPut]
        public async Task<IActionResult> BorrowBook(string bookId, int userId)
        {
            if (bookId == null)
                return BadRequest();

            await _bookService.BorrowBook(bookId, userId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ReturnBook(string bookId, int userId)
        {
            if (bookId == null)
                return BadRequest();

            await _bookService.ReturnBook(bookId, userId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetBookDetails(string bookId)
        {
            var result = await _bookService.GetBookDetails(bookId);
            return View("Details", result);
        }

        public async Task<UserViewModel> GetCurrentUser(int id)
        {
            return await _userService.GetUserDetails(id);
        }
    }
}
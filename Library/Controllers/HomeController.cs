using Library.DAL;
using Library.Models;
using Library.Services;
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
                //_context.Catalog.Add(new Book { Id="1", Title = "Carson" });
                //_context.Catalog.Add(new Book { Id = "2", Title = "Carson2" });
                //_context.SaveChanges();
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
            }
        }

        public IActionResult Index()
        {
            Console.WriteLine(_context.Books.Count());
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
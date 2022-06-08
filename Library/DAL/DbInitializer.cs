using Library.Models.Entity;
using System.Xml.Linq;

namespace Library.DAL
{
    internal class DbInitializer
    {
        internal static void Initialize(LibraryContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();
            if (dbContext.Catalog.Any()) return;

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

                dbContext.Catalog.Add(book);
                dbContext.SaveChanges();
            }

            dbContext.Catalog.Where(a => a.Id == "bk111").FirstOrDefault().BorrowerUserId = 2;
            dbContext.Catalog.Where(a => a.Id == "bk111").FirstOrDefault().BorrowedUntil = DateTime.Now.AddDays(5);
            dbContext.Catalog.Where(a => a.Id == "bk108").FirstOrDefault().BorrowerUserId = 2;
            dbContext.Catalog.Where(a => a.Id == "bk108").FirstOrDefault().BorrowedUntil = DateTime.Now.AddDays(7);
            dbContext.Catalog.Where(a => a.Id == "bk107").FirstOrDefault().BorrowerUserId = 3;
            dbContext.Catalog.Where(a => a.Id == "bk107").FirstOrDefault().BorrowedUntil = DateTime.Now.AddDays(3);

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
                    },
                    new User()
                    {
                        Id = 3,
                        Name = "Jack",
                        Surname = "Marston"
                    }
                };

            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();
        }
    }
}

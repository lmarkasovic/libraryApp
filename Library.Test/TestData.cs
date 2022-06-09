using Library.Models.DTO;
using Library.Models.Entity;

namespace Library.Test
{
    internal class TestData
    {
        public static IEnumerable<Book> GetTestCatalog()
        {
            var catalog = new List<Book>();
            catalog.Add(new Book()
            {
                Id = "1",
                Author = "Test One",
                Title = "Random title",
                BorrowerUserId = 1
            });
            catalog.Add(new Book()
            {
                Id = "2",
                Author = "Test Two",
                Title = "Example title",
                BorrowerUserId = 2,
            });
            catalog.Add(new Book()
            {
                Id = "3",
                Author = "Test Three",
                Title = "Example title",
                BorrowerUserId = null,
            });

            return catalog;
        }

        public static IEnumerable<BookDTO> GetTestCatalogDTO()
        {
            var catalog = new List<BookDTO>();

            catalog.Add(new BookDTO()
            {
                Id = "1",
                Author = "Test One",
                Title = "Random title",
                BorrowerUserId = 1,
                BorrowerNameSurname = "John Smith"
            });
            catalog.Add(new BookDTO()
            {
                Id = "2",
                Author = "Test Two",
                Title = "Example title",
                BorrowerUserId = null,
                BorrowerNameSurname = null
            });

            return catalog;
        }

        public static BookDetailsDTO GetTestBookDetailsDTO()
        {
            var book = new BookDetailsDTO()
            {
                Author = "Test One",
                Title = "Random title"
            };
            return book;
        }

        public static User GetTestUserDetails()
        {
            var user = new User()
            {
                Id = 1,
                Name = "John",
                Surname = "Smith"
            };
            return user;
        }

        public static UserDTO GetTestUsersDTO()
        {
            var user = new UserDTO()
            {
                Name = "John",
                Surname = "Smith"
            };
            return user;
        }


    }
}

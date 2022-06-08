using Library.Models.DTO;

namespace Library.Test
{
    internal class TestData
    {
        public static IEnumerable<BookDTO> GetTestCatalog()
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

        public static UserDTO GetTestUsers()
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

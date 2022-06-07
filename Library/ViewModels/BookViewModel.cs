
namespace Library.Models.ViewModels
{
    public class BookViewModel: BookViewModelBaseEntity
    {
        public string Id { get; set; }
        public int? BorrowerUserId { get; set; }
        public string? BorrowerNameSurname { get; set; }
        internal static BookViewModel FromDTO(Library.Models.DTO.BookDTO book)
        {
            return new BookViewModel
            {
                Author = book.Author,
                Title = book.Title,
                Id = book.Id,
                BorrowerUserId = book.BorrowerUserId,
                BorrowerNameSurname = book.BorrowerNameSurname
            };
        }
    }
}
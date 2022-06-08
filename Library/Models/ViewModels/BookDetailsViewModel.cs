
using System.ComponentModel.DataAnnotations;

namespace Library.Models.ViewModels
{
    public class BookDetailsViewModel: BookViewModelBaseEntity
    {
        public string Genre { get; set; }
        public string Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? BorrowedUntil { get; set; }

        internal static BookDetailsViewModel FromDTO(Library.Models.DTO.BookDetailsDTO book)
        {
            return new BookDetailsViewModel
            {
                Author = book.Author,
                Title = book.Title,
                Genre = book.Genre,
                Price = book.Price,
                PublishDate = book.PublishDate,
                Description = book.Description,
                Name = book.Name,
                Surname = book.Surname,
                BorrowedUntil = book.BorrowedUntil
            };
        }

    }
}
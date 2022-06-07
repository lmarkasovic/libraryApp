
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

    }
}
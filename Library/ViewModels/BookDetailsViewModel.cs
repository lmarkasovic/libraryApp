
namespace Library.Models.ViewModels
{
    public class BookDetailsViewModel: BookViewModelBaseEntity
    {
        public string Genre { get; set; }
        public string Price { get; set; }
        public string PublishDate { get; set; }
        public string Description { get; set; }
    }
}
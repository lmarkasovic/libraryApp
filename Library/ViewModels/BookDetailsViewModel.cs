
namespace Library.Models.ViewModels
{
    public class BookDetailsViewModel
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Price { get; set; }
        public string PublishDate { get; set; }
        public string Description { get; set; }
        public string? BorrowerName { get; set; }
        public string? BorrowerSurname { get; set; }
    }
}
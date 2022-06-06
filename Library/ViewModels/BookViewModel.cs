
namespace Library.Models.ViewModels
{
    public class BookViewModel
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int? BorrowerUserId { get; set; }
        public string? BorrowerName { get; set; }
        public string? BorrowerSurname { get; set; }
    }
}
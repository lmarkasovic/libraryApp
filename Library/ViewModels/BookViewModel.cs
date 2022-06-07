
namespace Library.Models.ViewModels
{
    public class BookViewModel: BookViewModelBaseEntity
    {
        public string Id { get; set; }
        public int? BorrowerUserId { get; set; }
        public string? BorrowerNameSurname { get; set; }
    }
}
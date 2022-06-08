namespace Library.Models.ViewModels
{
    public class BookViewModel : BookViewModelBaseEntity
    {
        public string Id { get; set; }
        public bool Borrowed { get; set; }
        public bool BorrowedByCurrentUser { get; set; }
        public string? BorrowerNameSurname { get; set; }
        internal static BookViewModel FromDTO(Library.Models.DTO.BookDTO book, int userId)
        {
            bool borrowed = false;
            bool borrowedByCurrentUser = false;
            if (book.BorrowerUserId != null) borrowed = true;
            if (userId == book.BorrowerUserId) borrowedByCurrentUser = true;
            return new BookViewModel
            {
                Author = book.Author,
                Title = book.Title,
                Id = book.Id,
                Borrowed = borrowed,
                BorrowedByCurrentUser = borrowedByCurrentUser,
                BorrowerNameSurname = book.BorrowerNameSurname
            };
        }
    }
}
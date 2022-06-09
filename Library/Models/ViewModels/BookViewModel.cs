namespace Library.Models.ViewModels
{
    public sealed class BookViewModel : BookViewModelBaseEntity
    {
        public string Id { get; set; }
        public bool Borrowed { get; set; }
        public bool BorrowedByCurrentUser { get; set; }
        public string? BorrowerNameSurname { get; set; }
        internal static BookViewModel FromDTO(Library.Models.DTO.BookDTO book)
        {
            return new BookViewModel
            {
                Author = book.Author,
                Title = book.Title,
                Id = book.Id,
                Borrowed = book.Borrowed,
                BorrowedByCurrentUser = book.BorrowedByCurrentUser,
                BorrowerNameSurname = book.BorrowerNameSurname
            };
        }
    }
}
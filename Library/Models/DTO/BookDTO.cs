namespace Library.Models.DTO
{
    public sealed class BookDTO: BookDTOBase
    {
        public string Id { get; set; }
        public int? BorrowerUserId { get; set; }
        public bool Borrowed { get; set; }
        public bool BorrowedByCurrentUser { get; set; }
        public string? BorrowerNameSurname { get; set; }
    }
}
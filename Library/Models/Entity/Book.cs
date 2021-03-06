namespace Library.Models.Entity
{
    public sealed class Book
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Price { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public int? BorrowerUserId { get; set; }
        public DateTime? BorrowedUntil { get; set; }
    }
}
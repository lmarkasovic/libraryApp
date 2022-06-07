namespace Library.Models.DTO
{
    public class BookDetailsDTO: BookDTOBase
    {
        public string Genre { get; set; }
        public string Price { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BorrowedUntil { get; set; }

    }
}
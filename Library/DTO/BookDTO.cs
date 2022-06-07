namespace Library.Models.DTO
{
    public class BookDTO: BookDTOBase
    {
        public string Id { get; set; }
        public int? BorrowerUserId { get; set; }
        public string? BorrowerNameSurname { get; set; }
    }
}
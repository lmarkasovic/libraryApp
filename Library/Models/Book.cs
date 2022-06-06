using System.Xml.Serialization;

namespace Library.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Price { get; set; }
        public string PublishDate { get; set; }
        public string Description { get; set; }
        public string? BorrowerUserId { get; set; }
    }
}
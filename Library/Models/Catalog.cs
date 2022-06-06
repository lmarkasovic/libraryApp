using System.Xml.Serialization;

namespace Library.Models
{
    [XmlRoot("catalog")]
    public class Catalog
    {
        [XmlElement("book")]
        public List<Book> Books { get; set; }
    }
}
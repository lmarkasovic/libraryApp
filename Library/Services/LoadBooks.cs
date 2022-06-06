using Library.Models;

namespace Library.Services
{
    public class LoadBooks
    {
        public void ReadXML()
        {
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Catalog));
            System.IO.StreamReader file = new System.IO.StreamReader(
                @"C:\Users\lukam\source\repos\Library\Library\books.xml");
            Catalog catalog = (Catalog)reader.Deserialize(file);
            file.Close();

            foreach (var book in catalog.Books)
            {
                Console.WriteLine(book.Author);
                Console.WriteLine(book.Title);
                Console.WriteLine(book.Genre);
                Console.WriteLine(book.Price);
                Console.WriteLine(book.PublishDate);
            }
        }
    }
}

using Archivum.Logic;

namespace Archivum.Models
{
    internal class Book : IModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Cover { get; set; } = new byte[0];
        public int PagesAmount { get; set; }
        public string Comment { get; set; }


        public Book()
        {

        }

        public Book(int id, string name, byte[] cover, int PagesAmount, string Comment)
        {
            ID = id;
            Name = name;
            Cover = cover;
            this.PagesAmount = PagesAmount;
            this.Comment = Comment;
        }
    }
}

using Archivum.Interfaces;
using SQLite;

namespace Archivum.Models.Text
{
    internal class Book : TextMaterial
    {
        public int PagesAmount { get; set; }
        public string Comment { get; set; }
        public Book()
        {

        }

        public Book(int id, string name, byte[] cover, int PagesAmount, string Comment) : base(id, name, cover)
        {
            this.PagesAmount = PagesAmount;
            this.Comment = Comment;
        }
    }
}

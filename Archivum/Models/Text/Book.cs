using Archivum.Interfaces;
using SQLite;

namespace Archivum.Models.Text
{
    internal class Book : TextMaterial
    {
        public int PagesAmount { get; set; }
        public string Comment { get; set; }
        public string СhaptersAmount { get; set; }

        public Book()
        {

        }

        public Book(int id, string name, byte[] cover, int status, int estimation, int PagesAmount, string Comment, string сhaptersAmount) : base(id, name, cover, status, estimation)
        {
            this.PagesAmount = PagesAmount;
            this.Comment = Comment;
            СhaptersAmount = сhaptersAmount;
        }
    }
}

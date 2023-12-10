using Archivum.Interfaces;
using SQLite;

namespace Archivum.Models.Text
{
    internal class Manga : TextMaterial
    {
        public int PagesAmount { get; set; }
        public string Comment { get; set; }

        public Manga()
        {

        }

        public Manga(int id, string name, byte[] cover, int PagesAmount, string Comment) : base(id, name, cover)
        {
            this.PagesAmount = PagesAmount;
            this.Comment = Comment;
        }
    }
}

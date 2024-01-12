using Archivum.Interfaces;
using SQLite;

namespace Archivum.Models.Text
{
    internal class Manga : TextMaterial
    {
        public string Comment { get; set; }
        public string СhaptersAmount { get; set; }

        public Manga()
        {

        }

        public Manga(int id, string name, byte[] cover, int status, int estimation, string Comment, string сhaptersAmount) : base(id, name, cover, status, estimation)
        {
            this.Comment = Comment;
            СhaptersAmount = сhaptersAmount;
        }
    }
}

using SQLite;
using Archivum.Interfaces;

namespace Archivum.Models.Video
{
    public class Film : VideoMaterial
    {
        public string Comment { get; set; }
        public int Filmlength { get; set; }

        public Film() { }
        public Film(int id, string name, string comment, byte[] cover, int filmlength) : base(id, name, cover)
        {
            Comment = comment;
            Filmlength = filmlength;
        }
    }
}

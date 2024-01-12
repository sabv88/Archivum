using SQLite;
using Archivum.Interfaces;

namespace Archivum.Models.Video
{
    public class Film : VideoMaterial
    {
        public string Comment { get; set; }
        public int Filmlength { get; set; }

        public Film() { }
        public Film(int id, string name, string comment, byte[] cover, int status, int estimation, int filmlength) : base(id, name, cover, status, estimation)
        {
            Comment = comment;
            Filmlength = filmlength;
        }
    }
}

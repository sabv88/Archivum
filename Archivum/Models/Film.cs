using SQLite;
using Archivum.Logic;

namespace Archivum.Models
{
    internal class Film : IModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Comment { get; set; }
        public byte[] Cover { get; set; } = new byte[0];
        public int Filmlength { get; set; }

        public Film() { }
        public Film(int iD, string name, string comment, byte[] cover, int filmlength)
        {
            ID = iD;
            Name = name;
            Comment = comment;
            Cover = cover;
            Filmlength = filmlength;
        }
    }
}

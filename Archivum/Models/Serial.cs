using Archivum.Logic;
using SQLite;

namespace Archivum.Models;

class Serial : IModel
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }
    public byte[] Cover { get; set; } = new byte[0];
    public int SeriesCount { get; set; }
    public int Serieslength { get; set; }

    public Serial() { }
    public Serial(int iD, string name, string comment, byte[] cover, int seriesCount, int serieslength)
    {
        ID = iD;
        Name = name;
        Comment = comment;
        Cover = cover;
        SeriesCount = seriesCount;
        Serieslength = serieslength;

    }
}


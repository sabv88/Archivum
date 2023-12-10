using Archivum.Interfaces;
using SQLite;

namespace Archivum.Models.Video;

public class Serial : VideoMaterial
{
    public string Comment { get; set; }
    public int SeriesCount { get; set; }
    public int Serieslength { get; set; }

    public Serial() { }
    public Serial(int id, string name, string comment, byte[] cover, int seriesCount, int serieslength) : base(id, name, cover)
    {
        Comment = comment;
        SeriesCount = seriesCount;
        Serieslength = serieslength;

    }
}


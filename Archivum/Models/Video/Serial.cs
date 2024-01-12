using Archivum.Interfaces;
using SQLite;

namespace Archivum.Models.Video;

public class Serial : VideoMaterial
{
    public string Comment { get; set; }
    public int SeriesCount { get; set; }
    public int Serieslength { get; set; }

    public Serial() { }
    public Serial(int id, string name, string comment, byte[] cover, int status, int estimation, int seriesCount, int serieslength) : base(id, name, cover, status, estimation)
    {
        Comment = comment;
        SeriesCount = seriesCount;
        Serieslength = serieslength;

    }
}


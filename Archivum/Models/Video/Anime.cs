using Archivum.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Models.Video
{
    public class Anime : VideoMaterial
    {
        public string Comment { get; set; }
        public string Waifu { get; set; }
        public int SeriesCount { get; set; }
        public int Serieslength { get; set; }
        public Anime()
        {

        }
        public Anime(int id, string name, string comment, int status, int estimation, byte[] cover, string waifu, int seriesCount, int serieslength) : base(id, name, cover, status, estimation)

        {
            Comment = comment;
            Waifu = waifu;
            SeriesCount = seriesCount;
            Serieslength = serieslength;
        }
    }
}

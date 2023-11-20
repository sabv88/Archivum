using Archivum.Logic;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Models
{
    public class Anime : IModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Comment { get; set; }
        public byte[] Cover { get; set; } = new byte[0];
        public string Waifu { get; set; }
        public int SeriesCount { get; set; }
        public int Serieslength { get; set; }
        public Anime()
        {

        }
        public Anime(int iD, string name, string comment, byte[] cover, string waifu, int seriesCount, int serieslength)
        {
            ID = iD;
            Name = name;
            Comment = comment;
            Cover = cover;
            Waifu = waifu;
            SeriesCount = seriesCount;
            Serieslength = serieslength;
        }
    }
}

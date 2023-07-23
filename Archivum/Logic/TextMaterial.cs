
using SQLite;

namespace Archivum.Logic
{
    public class TextMaterial
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Comment { get; set; }
        public byte[] Cover { get; set; } = new byte[0];
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Models.Video
{
    public class VideoMaterial : Material
    {
        public VideoMaterial(int id, string name, byte[] cover) : base(id, name, cover) { }
        public VideoMaterial() { }
    }
}

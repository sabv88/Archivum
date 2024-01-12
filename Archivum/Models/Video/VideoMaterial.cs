using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Models.Video
{
    public class VideoMaterial : Material
    {

        public VideoMaterial(int id, string name, byte[] cover, int status, int estimation) : base(id, name, cover, status, estimation) { }
        public VideoMaterial() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Models
{
    public class GamesMaterial : Material
    {
        public GamesMaterial(int id, string name, byte[] cover) : base(id, name, cover) { }
        public GamesMaterial() { }
    }
}

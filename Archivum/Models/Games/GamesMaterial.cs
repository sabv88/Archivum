using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Models
{
    public class GamesMaterial : Material
    {
        public GamesMaterial(int id, string name, byte[] cover, int status, int estimation) : base(id, name, cover, status, estimation) { }
        public GamesMaterial() { }
    }
}

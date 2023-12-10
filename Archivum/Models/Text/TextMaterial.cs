using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Models.Text
{
    public class TextMaterial : Material
    {
        public TextMaterial(int id, string name, byte[] cover) : base(id, name, cover) { }
        public TextMaterial() { }
    }
}

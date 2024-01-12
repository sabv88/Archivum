using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Models.Text
{
    public class TextMaterial : Material
    {
        public TextMaterial(int id, string name, byte[] cover, int status, int estimation) : base(id, name, cover, status, estimation)
        { 
        
        }
        public TextMaterial() { }
    }
}

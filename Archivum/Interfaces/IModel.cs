using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Interfaces
{
    public interface IModel
    {
        int ID { get; set; }
        string Name { get; set; }
        public byte[] Cover { get; set; }
        public int Status { get; set; }
        public int Estimation { get; set; }
    }
}

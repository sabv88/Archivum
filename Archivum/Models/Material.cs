using Archivum.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Models;

public class Material: IModel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public byte[] Cover { get; set; } = new byte[0];
    public Material()
    {

    }
    public Material(int id, string name, byte[] cover)
    {
        ID = id;
        Name = name;
        Cover = cover;
    }
}

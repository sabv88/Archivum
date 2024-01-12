using Archivum.Interfaces;
using SQLite;

namespace Archivum.Models;

public class Material: IModel
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Name { get; set; }
    public byte[] Cover { get; set; } = new byte[0];
    public int Status { get; set; } = 0;
    public int Estimation { get; set; } = 0;

    public Material()
    {

    }
    public Material(int id, string name, byte[] cover, int status, int estimation)
    {
        ID = id;
        Name = name;
        Cover = cover;
        Status = status;
        Estimation = estimation;
    }
}

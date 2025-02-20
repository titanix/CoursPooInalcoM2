using System.Buffers;

namespace Pokedex;

public interface IWriter
{
    bool SaveFile(Pokedex pokedex, string path);
    string GetJson(string path);
}
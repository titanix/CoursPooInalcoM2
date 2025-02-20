namespace Pokedex;

public interface IWriter
{
    bool SaveFile(Pokedex pokedex, string path);
}
namespace Pokedex;

public interface IWriter
{
    bool SaveFile(Pokedex pokedex, string path);

    Task<bool> SaveFileAsync(Pokedex pokedex, string path);
}
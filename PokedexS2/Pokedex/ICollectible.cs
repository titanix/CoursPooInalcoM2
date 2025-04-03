namespace Pokedex;

public interface ICollectible
{
    int Id { get; }
    string Name { get; }
    bool Discovered { get; }
    void Discover();
}
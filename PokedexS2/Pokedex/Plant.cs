namespace Pokedex;

public class Plant : ICollectible
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public bool Discovered { get; private set; }

    public Plant(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void Discover()
    {
        Discovered = true;
    }
}
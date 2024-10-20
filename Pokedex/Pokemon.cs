public class Pokemon
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public Type Type { get; private set; }

    public bool Discovered { get; private set; }

    public Pokemon(int id, string name, Type type)
    {
        Id = id;
        Name = name;
        Type = type;
    }

    public void Discover()
    {
        Discovered = true;
    }
}

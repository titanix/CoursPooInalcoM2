class Pokemon
{
    public int Id;

    public string Name;

    public Type Type;

    public bool Discovered;

    public Pokemon(int id, string name, Type type)
    {
        Id = id;
        Name = name;
        Type = type;
    }
}
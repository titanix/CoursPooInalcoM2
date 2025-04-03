namespace Pokedex;

public class Pokemon : ICollectible
{
    string separator = ";";

    public int Id { get; private set; }

    public string Name { get; private set; }

    public Type Type { get; private set; }

    public bool Discovered { get; private set; }

    public Pokemon(int id, string name, Type type)
        : this(id, name, type, false)
    {
    }

    public Pokemon(int id, string name, Type type, bool discovered)
    {
        Id = id;
        Name = name;
        Type = type;
        Discovered = discovered;
    }

    // Conversion depuis un objet spécialisé dans la lecture/écriture de données
    public Pokemon(PokemonDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        Type = dto.Type;
        Discovered = dto.Discovered;
    }

    // Conversion vers un objet spécialisé dans la lecture/écriture de données
    public PokemonDto ToDto()
    {
        PokemonDto dto = new PokemonDto()
        {
            Id = Id,
            Name = Name,
            Type = Type,
            Discovered = Discovered,
        };

        return dto;
    }

    public void Discover()
    {
        Discovered = true;
    }

    public override string ToString()
    {
        return $"{Id}{separator}{Name}{separator}{(int)Type}{separator}{Discovered}";
    }

    public static void Documentation()
    {
        Console.WriteLine("Classe qui représente un Pokémon");
    }
}

namespace Pokedex;

public class DiscoverCommand : Command
{
    public DiscoverCommand(Pokedex pokedex, string[] commandArguments)
        : base(pokedex, commandArguments)
    {
        if (commandArguments.Length < 1)
        {
            isValid = false;
        }
    }

    public override void Execute()
    {
        if (int.TryParse(arguments[0], out int id))
        {
            Discover(id);
        }
        else
        {
            Discover(arguments[0]);
        }
    }

    void Discover(string name)
    {
        Pokemon pokemon = Pokedex.GetByName(name);
        Console.WriteLine($"Pokemon {pokemon.Name} set to discovered");
        pokemon.Discover();
    }

    void Discover(int id)
    {
        Pokemon pokemon = Pokedex.Get(id);
        Console.WriteLine($"Pokemon {pokemon.Name} set to discovered");
        pokemon.Discover();
    }
}
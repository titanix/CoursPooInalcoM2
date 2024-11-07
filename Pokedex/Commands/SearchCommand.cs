public class SearchCommand
{
    Pokedex Pokedex;
    bool valid = true;
    string[] arguments;

    public SearchCommand(Pokedex pokedex, string[] commandArguments)
    {
        Pokedex = pokedex;

        if (commandArguments.Length < 1)
        {
            valid = false;
        }

        arguments = commandArguments;
    }

    public void Search()
    {
        if (!valid)
        {
            Console.Error.WriteLine("Not enough arguments for search command.");

            return;
        }

        Pokemon pokemon = Pokedex.Get(arguments[0]);
        if (pokemon != null)
        {
            Console.WriteLine($"Name: {pokemon.Name} ({pokemon.Id})");
            Console.WriteLine($"Type: {pokemon.Type}");
        }
        else
        {
            Console.WriteLine("Pokémon non trouvé !");
        }
    }
}
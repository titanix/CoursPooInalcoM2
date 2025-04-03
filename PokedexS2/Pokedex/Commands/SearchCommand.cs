namespace Pokedex;

public class SearchCommand : Command
{
    public SearchCommand(Pokedex pokedex, string[] commandArguments)
        : base(pokedex, commandArguments)
    {
        if (commandArguments.Length < 1)
        {
            isValid = false;
        }
    }

    public override void Execute()
    {
        if (!isValid)
        {
            Console.Error.WriteLine("Not enough arguments for search command.");

            return;
        }

        ICollectible collectible = Pokedex.Get(arguments[0]);
        if (collectible != null)
        {
            Console.WriteLine($"Name: {collectible.Name} ({collectible.Id})");
            // Console.WriteLine($"Type: {pokemon.Type}");
        }
        else
        {
            Console.WriteLine("Item non trouvé !");
        }
    }
}
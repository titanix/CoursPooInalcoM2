using System.Reflection.Metadata;

public class Program
{
    public static void Main(string[] args)
    {
        // INIT
        Pokedex pokedex = new Pokedex();
        // on peut désormais faire des choses avec le pokédex
        pokedex.Add(new Pokemon(25, "Pikachu", Type.Electric));

        pokedex.Add(new Pokemon(1, "Bulbizarre", Type.Grass | Type.Poison));
        pokedex.Add(new Pokemon(4, "Salamèche", Type.Fire));
        pokedex.Add(new Pokemon(6, "Dracaufeu", Type.Fire | Type.Flying));

        // TODO: new interpréteur de commande
        // TODO: utiliser l'interpréteur

        // TODO: à déplacer dans l'interpréteur
        if (args.Length > 1)
        {
            string command = args[0];

            if (command == "search")
            {
                SearchCommand cmd = new SearchCommand(pokedex);
            }

            if (command == "discover")
            {
            }
        }
        else
        {
            Console.Error.WriteLine("Mauvais nombre d'arguments");
            Console.Error.WriteLine("Usage: dotnet run [command] [argument]");
        }
    }
}
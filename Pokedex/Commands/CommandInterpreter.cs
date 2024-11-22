namespace PokedexPoo;

public class CommandInterpreter
{
    Pokedex pokedex;

    public CommandInterpreter(Pokedex pokedex)
    {
        // 'this' permet de faire référence au champ de la classe
        // plutôt qu'au paramètre de la méthode
        // 'this' n'est utile que quand l'argument à le même nom qu'un champ
        this.pokedex = pokedex;
    }
    
    public Command Interpret(string[] arguments)
    {
        if (arguments.Length < 1)
        {
            Console.Error.WriteLine("Not enough arguments!");

            new NopCommand();
        }

        string commandName = arguments[0];
        string[] commandArguments = arguments.Skip(1).ToArray();

        switch (commandName)
        {
            case "add":
                return new AddCommand(pokedex, commandArguments);

            case "search":
                return new SearchCommand(pokedex, commandArguments);

            case "discover":
                return new DiscoverCommand(pokedex, commandArguments);

            case "save":
                return new SaveCommand(pokedex, commandArguments);

            case "load":
                return new LoadCommand(pokedex, commandArguments);

            case "json":
                return new JsonCommand(pokedex, commandArguments);

            default:
                Console.Error.WriteLine($"Command '{commandName}' not recognized.");
                return new NopCommand();
        }
    }
}

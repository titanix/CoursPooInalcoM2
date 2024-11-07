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
    
    public void Interpret(string[] arguments)
    {
        if (arguments.Length < 1)
        {
            Console.Error.WriteLine("Not enough arguments!");
            //Console.Error.WriteLine("Available commands : add, search, discover, pokedex");

            return;
        }

        string commandName = arguments[0];
        string[] commandArguments = arguments.Skip(1).ToArray();

        switch (commandName)
        {
            case "add":
                AddCommand addCommand = new AddCommand(pokedex, commandArguments);
                addCommand.Add();
                break;

            case "search":
                SearchCommand searchCommand = new SearchCommand(pokedex, commandArguments);
                searchCommand.Search();
                break;

            case "discover":
                break;

            default:
                Console.Error.WriteLine($"Command '{commandName}' not recognized.");

                break;
        }
    }
}

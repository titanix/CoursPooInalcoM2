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
            //Console.Error.WriteLine("Available commands : add, search, discover, pokedex");

            throw new ArgumentException();
        }

        string commandName = arguments[0];
        string[] commandArguments = arguments.Skip(1).ToArray();

        switch (commandName)
        {
            case "add":
                AddCommand addCommand = new AddCommand(pokedex, commandArguments);
                return addCommand;

            case "search":
                SearchCommand searchCommand = new SearchCommand(pokedex, commandArguments);
                return searchCommand;

            //case "discover":
            //    break;

            default:
                Console.Error.WriteLine($"Command '{commandName}' not recognized.");
                throw new ArgumentException();
        }
    }
}

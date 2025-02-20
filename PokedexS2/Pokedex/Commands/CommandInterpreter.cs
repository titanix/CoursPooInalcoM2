using System.Text.RegularExpressions;
using System.Reflection;

namespace Pokedex;

public class CommandInterpreter
{
    Pokedex pokedex;
    LocalizationService localizationService;

    public CommandInterpreter(Pokedex pokedex, LocalizationService localizationService)
    {
        // 'this' permet de faire référence au champ de la classe
        // plutôt qu'au paramètre de la méthode
        // 'this' n'est utile que quand l'argument à le même nom qu'un champ
        this.pokedex = pokedex;
        this.localizationService = localizationService;
    }
    
    public Command Interpret(string[] arguments)
    {
        if (arguments.Length < 1)
        {
            Console.Error.WriteLine("Not enough arguments!");

            new NopCommand();
        }

        string commandName = arguments[0];
        //commandName = localizationService.GetText(commandName);
        string[] commandArguments = arguments.Skip(1).ToArray();

//         switch (commandName)
//         {
//             case "add":
//                 return new AddCommand(pokedex, commandArguments);

//             case "search":
//                 return new SearchCommand(pokedex, commandArguments);

//             case "discover":
//                 return new DiscoverCommand(pokedex, commandArguments);

//             case "save":
//                 return new SaveCommand(pokedex, commandArguments);

//             case "load":
//                 return new LoadCommand(pokedex, commandArguments);

//             case "write_json":
//                 return new WriteJsonCommand(pokedex, commandArguments);

//             case "read_json":
//                 return new ReadJsonCommand(pokedex, localizationService, commandArguments);

//             case "change_lang":
//                 return new ChangeLanguageCommand(pokedex, localizationService, commandArguments);

//             default:
//                 throw new CommandNotFoundException($"La commande {commandName} n'existe pas.");
// /*
//             default:
//                 Console.Error.WriteLine($"Command '{commandName}' not recognized.");
//                 return new NopCommand();
//                 */
//         }

        return MakeCommand(commandName, pokedex, commandArguments); 
    }

    private Command MakeCommand(string name, Pokedex pokedex, string[] commandArguments)
    {
        string commandName = "Pokedex." + name[0].ToString().ToUpper() + name.Substring(1) + "Command";
        
        Assembly assembly = Assembly.GetExecutingAssembly();
        System.Type type = assembly.GetType(commandName);

        object test = Activator.CreateInstance(type, new object[] { pokedex, commandArguments });
        
        return test as Command;
    }
}

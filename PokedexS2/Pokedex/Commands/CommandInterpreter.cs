using System.Reflection;
using System.Text.RegularExpressions;
using System.Linq;

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

    private Command MakeCommand(string name, Pokedex pokedex, string[] commandArguments)
    {
        string commandName = "";
        if (name == "SaveCommandUniq")
        {
            commandName = "Pokedex." + name;
        }
        else
        {
            if (name.Contains("_"))
            {
                Func<string, string> upper = (string mot) => mot[0].ToString().ToUpper()+mot.Substring(1);
                name = string.Join("", name.Split('_', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(upper).ToArray());
            }
            commandName = "Pokedex." + name[0].ToString().ToUpper() + name.Substring(1) + "Command";
        }
        Console.WriteLine(commandName);

        Assembly asm = Assembly.GetExecutingAssembly();
        System.Type type = asm.GetType(commandName);

        
        if (commandName.Contains("Read") || commandName.Contains("ChangeLanguage"))
        {
            var test = Activator.CreateInstance(type, new object[] {pokedex, localizationService, commandArguments});
            Console.WriteLine(test);
            return test as Command;
        }
        else
        {
            var test = Activator.CreateInstance(type, new object[] {pokedex, commandArguments});
            Console.WriteLine(test);
            return test as Command;
        }

        
    }
    
    public Command Interpret(string[] arguments)
    {
        if (arguments.Length < 1)
        {
            Console.Error.WriteLine("Not enough arguments!");

            return new NopCommand();
        }
        string commandName = arguments[0];
        string[] commandArguments = arguments.Skip(1).ToArray();
        if (commandName == "write_json" || commandName == "save")
        {
            commandName = "SaveCommandUniq";
            commandArguments = arguments;
        }
        //commandName = localizationService.GetText(commandName);
        return MakeCommand(commandName, pokedex, commandArguments);

//         switch (commandName)
//         {
//             case "test":
//                 return MakeCommand("add", pokedex, commandArguments);
                
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
    }
}

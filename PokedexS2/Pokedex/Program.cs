using System.Threading.Tasks;

namespace Pokedex;

public class Program
{
    public static async Task Main(string[] args)
    {
        Pokedex pokedex = new Pokedex();
        LocalizationService localizationService = new LocalizationService();
        CommandInterpreter interpreter = new CommandInterpreter(pokedex, localizationService);

        while (true)
        {
            Console.Write("$ ");
            string line = Console.ReadLine();
            string[] commandArgs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            try
            {
                Command command = interpreter.Interpret(commandArgs);
                switch (command)
                {
                    case LoadCommand loadCommand:
                        await loadCommand.ExecuteAsync();
                        break;

                    case ReadJsonCommand readJsonCommand:
                        await readJsonCommand.ExecuteAsync();
                        break;

                    case WriteJsonCommand writeJsonCommand:
                        await writeJsonCommand.ExecuteAsync();
                        break;

                    default:
                        command.Execute();
                        break;
                }
            }
            catch (CommandNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

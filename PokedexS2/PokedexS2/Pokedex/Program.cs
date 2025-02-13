using System.Globalization;

namespace Pokedex;

public class Program
{
    public static void Main(string[] args)
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
                command.Execute();
            }
            catch (CommandNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

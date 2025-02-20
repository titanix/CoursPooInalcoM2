using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Pokedex;

public class Program
{
    public static void DisplayItems(IEnumerable<int> list)
    {
        foreach (int n in list)
        {
            Console.WriteLine(n);
        }
    }

    public static void Main(string[] args)
    {
        // Iwriter jsonW = new JsonWriter();
        // jsonW.SaveFile("...");
        // Iwriter textW = new TextWriter();
        // textW.SaveFile("...");
        // JsonWriter jsonW2 = new JsonWriter();
        // jsonW2.GetJson();

        // int[] entiers = new int[3] {1,2,3};
        // Stack<int> stack = new Stack<int>();
        // stack.Push(9);
        // stack.Push(10);

        // List<int> list = new List<int>();
        // list.Add(4);
        // DisplayItems(entiers);
        // DisplayItems(stack);
        // DisplayItems(list);
        // Environment.Exit(0);


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

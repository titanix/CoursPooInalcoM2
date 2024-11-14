public class Program
{
    public static void Main(string[] args)
    {
        Pokedex pokedex = new Pokedex();
        CommandInterpreter interpreter = new CommandInterpreter(pokedex);

        while (true)
        {
            Console.Write("$ ");
            string line = Console.ReadLine();
            string[] commandArgs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            Command command = interpreter.Interpret(commandArgs);
            command.Execute();
        }
    }
}

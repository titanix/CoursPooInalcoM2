public class Program
{
    public static void Main(string[] args)
    {
        Pokedex pokedex = new Pokedex();

        pokedex.Add(new Pokemon(25, "Pikachu", Type.Electric));
        pokedex.Add(new Pokemon(1, "Bulbizarre", Type.Grass | Type.Poison));
        pokedex.Add(new Pokemon(4, "Salamèche", Type.Fire));
        pokedex.Add(new Pokemon(6, "Dracaufeu", Type.Fire | Type.Flying));

        while (true)
        {
            Console.Write("$ ");
            string line = Console.ReadLine();
            string[] commandArgs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            CommandInterpreter interpreter = new CommandInterpreter(pokedex);
            interpreter.Interpret(commandArgs);
        }
    }
}
namespace Pokedex;
public class AddPlantCommand : Command
{
    public AddPlantCommand(Pokedex pokedex, string[] commandArguments)
        : base(pokedex, commandArguments)
    {
        if (commandArguments.Length < 2)
        {
            isValid = false;
        }
    }
    public override void Execute()
    {
        if (!isValid)
        {
            Console.Error.WriteLine($"Not enough arguments");

            return;
        }

        if (!int.TryParse(arguments[0], out int plantIndex))
        {
            Console.Error.WriteLine($"Error parsing id '{arguments[0]}'");

            return;
        }

        string plantName = arguments[1];

        // l'exécution via le pokedex
        Plant plant = new Plant(plantIndex, plantName);
        Pokedex.Add(plant);

        Console.WriteLine($"Plant {plant.Name} added to the pokedex.");
    }
}
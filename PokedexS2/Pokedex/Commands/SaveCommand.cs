namespace Pokedex;

// save <fichier>
public class SaveCommand : Command
{
    string saveDirecty = "Data";

    public SaveCommand(Pokedex pokedex, string[] commandArguments)
        : base(pokedex, commandArguments)
    {
        if (commandArguments.Length < 1)
        {
            isValid = false;
        }
    }

    public override void Execute()
    {
        if (isValid) {
            IWriter writer = new TextWriter();
            string path = arguments[0];
            writer.SaveFile(Pokedex, path);

            Console.WriteLine($"Pokedex saved to file {path}");
        }
        else {
            Console.WriteLine("Invalid command");
        }
        
    }
}
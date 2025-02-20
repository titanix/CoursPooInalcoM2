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
        if (isValid)
        {
            IWriter writer = new TextWriter();
            string path = $"{saveDirecty}/{arguments[0]}.txt";
            writer.SaveFile(Pokedex, path);
        }
        else
        {
            Console.WriteLine("Argument manquant.");
        }
    }
}
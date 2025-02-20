using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Pokedex;

// Sérialise le Pokedex sous forme de JSON
public class WriteJsonCommand : Command
{
    string saveDirecty = "Data";

    public WriteJsonCommand(Pokedex pokedex, string[] commandArguments)
        : base(pokedex, commandArguments)
    {
    }

    public override void Execute()
    {
        
        string path = $"{saveDirecty}/{arguments[0]}.json";
        IWriter writer = new JsonWriter();
        writer.SaveFile(Pokedex, path);

        Console.WriteLine("Fichier bien sauvegardé.");
    }
}
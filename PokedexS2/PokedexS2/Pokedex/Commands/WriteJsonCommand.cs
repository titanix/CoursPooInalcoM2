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
        // Cette classe permet de configurer comment est écrit le fichier JSON
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            // Le comporte par défault du sérialiseur est débile et échappe tous les caractères non ASCII
            // par exemple Salamèche -> Salam\u00E8che. Pour éviter ça on utilise l'option qui suit
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement),
        };

        PokedexDto pokedexDto = Pokedex.ToDto();
        string jsonString = JsonSerializer.Serialize(pokedexDto, options);
        string path = $"{saveDirecty}/{arguments[0]}.json";
        File.WriteAllText(path, jsonString);

        Console.WriteLine("Fichier bien sauvegardé.");
    }
}
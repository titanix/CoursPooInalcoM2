using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Pokedex;

// Désérialise le Pokedex sous forme de JSON
public class ReadJsonCommand : Command
{
    LocalizationService localizationService;

    string saveDirecty = "Data";

    public ReadJsonCommand(
        Pokedex pokedex,
        LocalizationService localizationService,
        string[] commandArguments)
        : base(pokedex, commandArguments)
    {
        this.localizationService = localizationService;
    }

    public override void Execute()
    {

        string path = $"{saveDirecty}/{arguments[0]}.json";

        Ireader jsonReader = new JsonReader();
        Pokedex = jsonReader.ReadFile(path, Pokedex, localizationService);
        // JsonSerializerOptions options = new JsonSerializerOptions
        // {
        //     WriteIndented = true,
        //     PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        //     // Le comporte par défault du sérialiseur est débile et échappe tous les caractères non ASCII
        //     // par exemple Salamèche -> Salam\u00E8che. Pour éviter ça on utilise l'option qui suit
        //     Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement),
        // };

        // try
        // {
        //     string path = $"{saveDirecty}/{arguments[0]}.json";
        //     string content = File.ReadAllText(path);

        //     PokedexDto pokedexDto = JsonSerializer.Deserialize<PokedexDto>(content, options);
        //     Pokedex.LoadDto(pokedexDto);

        //     //Console.WriteLine("Fichier chargé.");
        //     string message = localizationService.GetText("msg.FileLoaded");
        //     Console.WriteLine(message);
        // }
        // catch// (FileNotFoundException e)
        // {
        //     Console.WriteLine("Fichier non trouvé");
        // }
    }
}
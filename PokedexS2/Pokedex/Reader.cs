namespace Pokedex;

using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
public interface Ireader
{
    Pokedex ReadFile(string path, Pokedex p, LocalizationService localizationService);
}

public class JsonReader : Ireader
{
    public Pokedex ReadFile(string path, Pokedex p, LocalizationService localizationService)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            // Le comporte par défault du sérialiseur est débile et échappe tous les caractères non ASCII
            // par exemple Salamèche -> Salam\u00E8che. Pour éviter ça on utilise l'option qui suit
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement),
        };

        try
        {
            string content = File.ReadAllText(path);

            PokedexDto pokedexDto = JsonSerializer.Deserialize<PokedexDto>(content, options);
            p.LoadDto(pokedexDto);

            //Console.WriteLine("Fichier chargé.");
            string message = localizationService.GetText("msg.FileLoaded");
            Console.WriteLine(message);
        }
        catch// (FileNotFoundException e)
        {
            Console.WriteLine("Fichier non trouvé");
        }
        return p;
    }
}
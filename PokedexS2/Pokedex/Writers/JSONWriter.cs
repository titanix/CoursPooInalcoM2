using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Pokedex;

public class JsonWriter : IWriter
{
    public bool SaveFile(Pokedex pokedex, string path)
    {
        try
        {
            string content = GetJson(pokedex);
            File.WriteAllText(path, content);

            Console.WriteLine("Fichier bien sauvegardé.");
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);

            return false;
        }

        return true;
    }
    
    public async Task<bool> SaveFileAsync(Pokedex pokedex, string path)
    {
        try
        {
            string content = GetJson(pokedex);
            await File.WriteAllTextAsync(path, content);

            Console.WriteLine("Fichier bien sauvegardé.");
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);

            return false;
        }

        return true;
    }

    private string GetJson(Pokedex pokedex)
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

        PokedexDto pokedexDto = pokedex.ToDto();
        string jsonString = JsonSerializer.Serialize(pokedexDto, options);

        return jsonString;
    }
}
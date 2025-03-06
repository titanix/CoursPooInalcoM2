using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;


namespace Pokedex;
public class OldJsonWriter: IWriter
{
    JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            // Le comporte par défault du sérialiseur est débile et échappe tous les caractères non ASCII
            // par exemple Salamèche -> Salam\u00E8che. Pour éviter ça on utilise l'option qui suit
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement),
        };
    public bool SaveFile(Pokedex pokedex, string path)
    {
        try
        {
            PokedexDto pokedexDto = pokedex.ToDto();
            string jsonString = JsonSerializer.Serialize(pokedexDto, options);
            File.WriteAllText(path, jsonString);
        }
        catch
        {
            Console.Error.WriteLine("Erreur lors de la sauvegarde du fichier");
            return false;
        }
        return true;
    }

    public string GetJson(string path)
    {
        string content = File.ReadAllText(path);

        return content;
    }
}
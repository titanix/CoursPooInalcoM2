namespace Pokedex;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

public class JsonWriter : Iwriter
{
    public bool SaveFile(string path, Pokedex p)
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

        PokedexDto pokedexDto = p.ToDto();
        string jsonString = JsonSerializer.Serialize(pokedexDto, options);
        File.WriteAllText(path, jsonString);

        Console.WriteLine("Fichier bien sauvegardé.");
        return true;
    }

    public string GetJson()
    {
        return "";
    }
}

public class TxtWriter : Iwriter
{
    public bool SaveFile(string path, Pokedex p) // Pour conformer à l'interface, la portée doit aussi identique
    {
        // Vrai code
        StreamWriter streamWriter = new StreamWriter(path);

        p.Save(streamWriter);
        streamWriter.Flush();
        streamWriter.Close();

        Console.WriteLine($"Pokedex saved to file {path}");
        return true;
    }
}

public interface Iwriter
{
    bool SaveFile(string path, Pokedex p);
}
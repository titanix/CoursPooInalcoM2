using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Xml.Serialization;

namespace Pokedex;

public class TextWriter : IWriter
{
    public bool SaveFile(string filePath, Pokedex pokedex)
    {
        try
        {
            StreamWriter streamWriter = new StreamWriter(filePath
            );
            pokedex.Save(streamWriter);
            streamWriter.Flush();
            streamWriter.Close();
            Console.WriteLine($"Pokedex saved to file {filePath}");
        }
        catch
        {
            Console.Error.WriteLine("An error occured while saving the file");
        }
        return true;
    }

    
}

public class JsonWriter : IWriter // JsonWriter est de type IWriter
{

    // Sauvegarde le Pokedex sous forme de fichier JSON dont le nom est passé en paramètre
    public bool SaveFile(string filePath, Pokedex pokedex)
    {
        try
        {
            string content = GetJson(pokedex);
            File.WriteAllText(filePath, content);
            Console.WriteLine($"Pokedex saved to file {filePath}");
        }
        catch
        {
            Console.Error.WriteLine("An error occured while saving the file");
        }

        return true;
    }


    public string GetJson(Pokedex pokedex)
    {
        // Configuration des options de sérialisation JSON
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            // On suppose que JsonNamingPolicy.SnakeCaseLower est une implémentation personnalisée
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            // Pour éviter que le sérialiseur n'échappe les caractères non-ASCII (ex : Salamèche)
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement)
        };

        PokedexDto pokedexDto = pokedex.ToDto();
        string jsonString = JsonSerializer.Serialize(pokedexDto, options);

        return jsonString;
    }
}


public class XMLWriter : IWriter
{
    public bool SaveFile(string filePath, Pokedex pokedex)
    {
        try
        {
                string content = GetXml(pokedex);
                File.WriteAllText(filePath, content);
                Console.WriteLine($"Pokedex saved to file {filePath}");
        }
        catch
        {
                Console.Error.WriteLine("An error occured while saving the file");
        }
        return true;
    }

    public string GetXml(Pokedex pokedex)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(PokedexDto));
        StringWriter stringWriter = new StringWriter();
        xmlSerializer.Serialize(stringWriter, pokedex.ToDto());
        return stringWriter.ToString();
    }
}



public interface IWriter
{
    bool SaveFile(string filePath, Pokedex pokedex);
}
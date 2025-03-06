namespace Pokedex;

public class OldTextWriter : IWriter
{
    string saveDirecty = "Data";
    public bool SaveFile(Pokedex pokedex, string path)
    {
        try
        {
            path = $"{saveDirecty}/{AddExtension(path)}";
            Directory.CreateDirectory(saveDirecty);

            StreamWriter streamWriter = new StreamWriter(path);

            pokedex.Save(streamWriter);
            streamWriter.Flush();
            streamWriter.Close();

            Console.WriteLine($"Pokedex saved to file {path}");
        }
        catch
        {
            Console.Error.WriteLine("Error saving pokedex to file");
            return false;
        }
        
        return true;
    }

    string AddExtension(string path)
    {
        if (!path.Contains("."))
        {
            return $"{path}.csv";
        }

        return path;
    }

    public string GetJson(string path)
    {
        throw new NotImplementedException();
    }
}
namespace Pokedex;

/*
public class TextWriter : IWriter
{
    public bool SaveFile(Pokedex pokedex, string path)
    {
        // TODO: if valid
        string path = AddExtension(arguments[0]);
        path = $"{saveDirecty}/{path}";
        Directory.CreateDirectory(saveDirecty);

        StreamWriter streamWriter = new StreamWriter(path);

        SavePokedex(streamWriter);
        streamWriter.Flush();
        streamWriter.Close();

        Console.WriteLine($"Pokedex saved to file {path}");

        return true;
    }

    void SavePokedex(StreamWriter file)
    {
        Pokedex.Save(file);
    }

    string AddExtension(string path)
    {
        if (!path.Contains("."))
        {
            return $"{path}.csv";
        }

        return path;
    }
}
    */
// save <fichier>
public class SaveCommand : Command
{
    string saveDirecty = "Data";

    public SaveCommand(Pokedex pokedex, string[] commandArguments)
        : base(pokedex, commandArguments)
    {
        if (commandArguments.Length < 1)
        {
            isValid = false;
        }
    }

    public override void Execute()
    {
        string path = AddExtension(arguments[0]);
        path = $"{saveDirecty}/{path}";
        Directory.CreateDirectory(saveDirecty);

        StreamWriter streamWriter = new StreamWriter(path);

        SavePokedex(streamWriter);
        streamWriter.Flush();
        streamWriter.Close();
    }

    void SavePokedex(StreamWriter file)
    {
        Pokedex.Save(file);
    }

    string AddExtension(string path)
    {
        if (!path.Contains("."))
        {
            return $"{path}.txt";
        }

        return path;
    }
}
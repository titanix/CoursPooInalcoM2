using System.Reflection;
namespace Pokedex;

public class SaveCommandUniq : Command
{
    string saveDirecty = "Data";

    public SaveCommandUniq(Pokedex pokedex, string[] commandArguments)
        : base(pokedex, commandArguments)
    {
    }
    private Iwriter GetWriter(string type)
    {
        Assembly asm = Assembly.GetExecutingAssembly();
        System.Type CommandType = asm.GetType("Pokedex."+type[0].ToString().ToUpper()+type.Substring(1)+"Writer");
        if (CommandType == null)
        {
            throw new InvalidOperationException($"Il faut choisir le format entre 'json' et 'txt'.");
        }

        object Writer = Activator.CreateInstance(CommandType);

        return Writer as Iwriter;
    }

    string AddExtension(string path)
    {
        if (!path.Contains("."))
        {
            return $"{path}.csv";
        }

        return path;
    }

    public override void Execute()
    {
        string path = arguments[1];
        string type = "";
        if (arguments[0] == "write_json")
        {
            path = $"{saveDirecty}/{path}.json";
            type = "json";
        }
        else if (arguments[0] == "save")
        {
            path = AddExtension(path);
            path = $"{saveDirecty}/{path}";
            type = "txt";
        }
        Directory.CreateDirectory(saveDirecty);
        Iwriter writer = GetWriter(type);
        writer.SaveFile(path, Pokedex);
        
    }
}
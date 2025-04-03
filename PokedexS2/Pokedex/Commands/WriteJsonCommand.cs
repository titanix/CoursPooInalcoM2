using System.Threading.Tasks;

namespace Pokedex;

// Sérialise le Pokedex sous forme de JSON
public class WriteJsonCommand : Command
{
    string saveDirecty = "Data";

    public WriteJsonCommand(Pokedex pokedex, string[] commandArguments)
        : base(pokedex, commandArguments)
    {
        if (commandArguments.Length != 1)
        {
            isValid = false;
        }
    }
    public override void Execute()
    {
        throw new NotImplementedException();
    }
    
    public async Task ExecuteAsync()
    {
        if (isValid)
        {
            IWriter writer = new JsonWriter();
            string path = $"{saveDirecty}/{arguments[0]}.json";
            await writer.SaveFileAsync(Pokedex, path);
        }
        else
        {
            Console.WriteLine("Argument manquant.");
        }
    }

    // TODO : faire une commande unique qui refactore WriteJsonCmd et SaveCmd
    // qui contient private IWriter GetWriter(string format)
    // (bonus: ajout xml)
}
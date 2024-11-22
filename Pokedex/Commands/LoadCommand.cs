namespace PokedexPoo;

public class LoadCommand : Command
{
    public LoadCommand(Pokedex pokedex, string[] commandArguments)
        : base(pokedex, commandArguments)
    {
        if (commandArguments.Length < 1)
        {
            isValid = false;
        }
    }

    public override void Execute()
    {
        if (!isValid)
        {
            Console.Error.WriteLine("Nombre d'argument insuffisant");

            return;
        }

        string path = arguments[0];

        if (!File.Exists(path))
        {
            Console.Error.WriteLine($"File [{path}] not found");

            return;
        }

        StreamReader reader = new StreamReader(path);

        int count = 0;
        while(!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split(";");
            if (parts.Length != 4)
            {
                Console.Error.WriteLine($"Error loading line [{line}]");

                continue;
            }

            // TODO: validation plus sérieuse
            int id = int.Parse(parts[0]);
            string name = parts[1];
            // TODO: il faudrait être sérieux à l'avenir
            Type.TryParse(parts[2], out Type type);
            bool discovered = bool.Parse(parts[3]);

            Pokemon pokemon = new Pokemon(id, name, type, discovered);
            // TODO: vérifier que le pokémon n'est pas déjà chargé
            // demander si on doit l'écraser ou pas
            Pokedex.Add(pokemon);

            count++;
        }

        Console.WriteLine($"{count} pokemons loaded from file.");

        reader.Close();
    }
}
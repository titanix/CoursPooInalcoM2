internal class CommandInterpreter
{
    private string[] Arguments;
    private Pokedex Pokedex;
    internal CommandInterpreter(string[] arguments, Pokedex pokedex)
    {
        Arguments = arguments;
        Pokedex = pokedex;
    }

    internal void Interpret()
    {
        if(Arguments.Length < 1)
        {
            Console.WriteLine("Available commands : add, search, discover, pokedex");
            return;
        }
        string command = Arguments[0];
        if(command == "add")
        {
            ParseAddCommand();
        }
        else if(command == "search")
        {
            ParseSearchCommand();
        }
        else if(command == "discover")
        {
            ParseDiscoverCommand();
        }
        else if(command == "pokedex")
        {
            ParsePokedexCommand();
        }
        else
        {
            Console.WriteLine("Available commands : add, search, discover, pokedex");
            return;
        }
        
    }

    private void ParseAddCommand()
    {
        if(Arguments.Length < 4 || Arguments.Length > 5)
        {
            Console.WriteLine("Usage : add index name type (type)");
            return;
        }
        int index;
        Type type1;
        Type type2 = 0;

        if(! int.TryParse(Arguments[1], out index))
        {
            Console.WriteLine("Index must be int between 1 and 151. Usage : add index name type (type).");
            return;
        }

        if(! Enum.TryParse(Arguments[3],out type1))
        {
            Console.WriteLine($"Unrecognized type {type1}. Usage : add index name type (type).");
            return; 
        }

        if(Arguments.Length == 5)
        {
            if(! Enum.TryParse(Arguments[4],out type2))
            {
                Console.WriteLine($"Unrecognized type {type2}. Usage : Aad index name type (type).");
                return; 
            } 
        }
        string name = Arguments[2];
        AddCommand.Add(Pokedex, index, name, type1, type2);
    }

    private void ParseSearchCommand()
    {
        if(Arguments.Length != 2)
        {
            Console.WriteLine("Usage : search name");
            return;
        }
        string name = Arguments[1];
        SearchCommand.Search(Pokedex, name);
    }

    private void ParseDiscoverCommand()
    {

        if(Arguments.Length != 2)
        {
            Console.WriteLine("Usage : discover name");
            return;
        }
        string name = Arguments[1];
        DiscoverCommand.Discover(Pokedex,name);

    }

    private void ParsePokedexCommand()
    {
        if(Arguments.Length != 1)
        {
            Console.WriteLine("Usage : pokedex");
            return;
        }
        PokedexCommand.Pokedex(Pokedex);
    }
}
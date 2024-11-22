namespace PokedexPoo;

public class AddCommand : Command
{
    public AddCommand(Pokedex pokedex, string[] commandArguments)
        : base(pokedex, commandArguments)
    {
        if (commandArguments.Length < 3)
        {
            isValid = false;
        }
    }

    // (add) 25 Pickachu Electric [Fire]
    public override void Execute()
    {
        if (!isValid)
        {
            Console.Error.WriteLine($"Not enough arguments");

            return;
        }

        // Parser les 3 arguments
        if (!int.TryParse(arguments[0], out int pokemonIndex))
        {
            Console.Error.WriteLine($"Error parsing id '{arguments[0]}'");

            return;
        }

        string pokemonName = arguments[1];

        if (!Type.TryParse(arguments[2], out Type pokemonType))
        {
            Console.Error.WriteLine($"Type {arguments[2]} not recognized");

            return;
        }

        if (arguments.Length == 4)
        {
            if(!Type.TryParse(arguments[3], out Type secondPokemonType))
            {
                Console.Error.WriteLine($"Type {arguments[3]} not recognized");

                return;
            }
            // est équivalent à pokemonType = pokemonType | secondPokemonType;
            pokemonType |= secondPokemonType;

        }

        // l'exécution via le pokedex
        Pokemon pokemon = new Pokemon(pokemonIndex, pokemonName, pokemonType);
        Pokedex.Add(pokemon);

        Console.WriteLine($"Pokemon {pokemon.Name} added to the pokedex.");
    }
}
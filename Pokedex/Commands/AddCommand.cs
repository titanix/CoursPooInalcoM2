public class AddCommand
{
    Pokedex Pokedex;
    string[] arguments;

    public AddCommand(Pokedex pokedex, string[] commandArguments)
    {
        Pokedex = pokedex;
        arguments = commandArguments;

        //validation
    }

    public void Add()
    {
        // int index, string name, Type type

        // Parser les 3 arguments
        if(!int.TryParse(arguments[0], out int pokemonIndex))
        {
            // cas d'erreur (parsing incorrect)
        }

        string pokemonName = arguments[1];

        if(!Type.TryParse(arguments[2], out Type pokemonType))
        {
            // cas d'erreur (parsing incorrect)
        }

        // l'exécution via le pokedex
        Pokemon pokemon = new Pokemon(pokemonIndex, pokemonName, pokemonType);
        Pokedex.Add(pokemon);
    }
}
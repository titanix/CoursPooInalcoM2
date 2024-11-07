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

    public override void Execute()
    {
        // Parser les 3 arguments
        if (!int.TryParse(arguments[0], out int pokemonIndex))
        {
            // TODO: cas d'erreur (parsing incorrect)
        }

        string pokemonName = arguments[1];

        if (!Type.TryParse(arguments[2], out Type pokemonType))
        {
            // TODO: cas d'erreur (parsing incorrect)
        }

        // l'exécution via le pokedex
        Pokemon pokemon = new Pokemon(pokemonIndex, pokemonName, pokemonType);
        Pokedex.Add(pokemon);
    }
}
namespace PokedexPoo;
// Affiche le nombre de pokémon contenu dans le pokedex
public class CountCommand : Command
{
    public CountCommand(Pokedex pokedex, string[] commandArguments)
        : base(pokedex, commandArguments)
    {
    }

    public override void Execute()
    {
        // TODO
    }
}
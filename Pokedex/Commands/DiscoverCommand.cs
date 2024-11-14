public class DiscoverCommand : Command
{
    public DiscoverCommand(Pokedex pokedex)
    {
        Pokedex = pokedex;
    }

    public void Discover(string name)
    {
        Pokemon pokemon = Pokedex.Get(name);
        pokemon.Discover();
    }

    public override void Execute()
    {
        throw new NotImplementedException();
    }
}
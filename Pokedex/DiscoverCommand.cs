internal static class DiscoverCommand
{
    internal static void Discover(Pokedex pokedex, string name)
    {
        Pokemon pokemon = pokedex.GetPokemon(name);
        if(pokemon == null)
        {
            Console.WriteLine("Pokemon non trouvé");
            return;
        }
        pokedex.DiscoverPokemon(pokemon);
    }
}
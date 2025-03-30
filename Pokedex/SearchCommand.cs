internal static class SearchCommand
{
    internal static void Search(Pokedex pokedex, string name)
    {
        Pokemon pokemon = pokedex.GetPokemon(name);
        if(pokemon == null)
        {
            Console.WriteLine("Pokemon non trouvé");
            return;
        }
        pokemon.PrintPokemon();
    }
}
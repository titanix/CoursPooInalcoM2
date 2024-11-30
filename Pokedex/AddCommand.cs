internal static class AddCommand
{
    internal static void Add(Pokedex pokedex, int index, string name, Type type1, Type type2)
    {
        Type type = type1 | type2;
        Pokemon pokemon = new Pokemon(name, type, false, index);
        pokedex.AddPokemon(pokemon);
    }
}
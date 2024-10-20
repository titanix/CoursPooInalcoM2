public class SearchCommand
{
    Pokedex Pokedex;

    public SearchCommand(Pokedex pokedex)
    {
        Pokedex = pokedex;
    }

    public void Search(string name)
    {
        Pokemon pokemon = Pokedex.Get(name);
        if (pokemon != null)
        {
            Console.WriteLine($"Name: {pokemon.Name} ({pokemon.Id})");
            Console.WriteLine($"Type: {pokemon.Type}");
        }
        else
        {
            Console.WriteLine("Pokémon non trouvé !");
        }
    }
}
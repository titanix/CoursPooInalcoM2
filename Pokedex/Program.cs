public class Program
{
    public static void Main(string[] args)
    {
        Pokedex pokedex = new Pokedex();
        // on peut désormais faire des choses avec le pokédex
        pokedex.Add(new Pokemon(25, "Pikachu", Type.Electric));
    }
}
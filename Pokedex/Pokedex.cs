// https://www.pokepedia.fr/Liste_des_Pok%C3%A9mon_dans_l%27ordre_du_Pok%C3%A9dex_National
class Pokedex
{
    Pokemon[] pokemons = new Pokemon[151];

    public void Add(Pokemon p)
    {
        pokemons[p.Id - 1] = p;
    }

    public void Discover(Pokemon p)
    {
        pokemons[p.Id - 1].Discovered = true;
    }

    public Pokemon Get(int id)
    {
        return pokemons[id - 1];
    }

    public Pokemon Get(string name)
    {
        // boucle jusqu'à un pokémon nommé name
            // foreach
            // if
            // return
        return null;
    }

    public Pokemon[] GetByType(Type type)
    {
        throw new NotImplementedException();
    }
}
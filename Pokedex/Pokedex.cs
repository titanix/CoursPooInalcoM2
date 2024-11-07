// https://www.pokepedia.fr/Liste_des_Pok%C3%A9mon_dans_l%27ordre_du_Pok%C3%A9dex_National
public class Pokedex
{
    Pokemon[] pokemons = new Pokemon[151];

    public void Add(Pokemon p)
    {
        pokemons[p.Id - 1] = p;
    }

    public void Discover(Pokemon p)
    {
        p.Discover();
    }

    public Pokemon Get(int id)
    {
        return pokemons[id - 1];
    }

    public Pokemon Get(string name)
    {
        foreach (Pokemon pokemon in pokemons)
        {
            if (pokemon != null && pokemon.Name.ToLower() == name.ToLower())
            {
                return pokemon;
            }
        }

        return null;
    }

    public Pokemon[] GetByType(Type type)
    {
        int arraySize = 0;
        foreach(Pokemon pokemon in pokemons)
        {
            if (pokemon != null && pokemon.Type.HasFlag(type))
            {
                arraySize++;
            }
        }

        int index = 0;
        Pokemon[] result = new Pokemon[arraySize];
        foreach(Pokemon pokemon in pokemons)
        {
            if (pokemon != null && pokemon.Type.HasFlag(type))
            {
                result[index++] = pokemon;
            }
        }

        return result;
    }
/*
    public IEnumerable<Pokemon> GetByTypeEnumerable(Type t)
    {
        foreach (Pokemon p in pokemons)
        {
            if (p != null && p.Type == t)
            {
                yield return p;
            }
        }
    }
*/
}

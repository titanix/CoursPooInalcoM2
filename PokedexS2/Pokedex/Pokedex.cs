// https://www.pokepedia.fr/Liste_des_Pok%C3%A9mon_dans_l%27ordre_du_Pok%C3%A9dex_National
namespace Pokedex;

public class Pokedex
{
    ICollectible[] collectibles = new ICollectible[151];

    public Pokedex()
    {
    }

    public Pokedex(PokedexDto pokedexDto)
    {
        LoadDto(pokedexDto);
    }

    public void LoadDto(PokedexDto pokedexDto)
    {
        throw new NotImplementedException();
        // foreach (PokemonDto pokemonDto in pokedexDto.Pokemons)
        // {
        //     Pokemon pokemon = new Pokemon(pokemonDto);
        //     pokemons[pokemon.Id] = pokemon;
        // }
    }

    public void Add(ICollectible p)
    {
        collectibles[p.Id - 1] = p;
    }

    public void Discover(ICollectible p)
    {
        p.Discover();
    }

    public ICollectible Get(int id)
    {
        return collectibles[id - 1];
    }

    public ICollectible Get(string name)
    {
        foreach (ICollectible collectible in collectibles)
        {
            if (collectible != null && collectible.Name.ToLower() == name.ToLower())
            {
                return collectible;
            }
        }

        return null;
    }

    public Pokemon[] GetByType(Type type)
    {
        // int arraySize = 0;
        // foreach (Pokemon pokemon in pokemons)
        // {
        //     if (pokemon != null && pokemon.Type.HasFlag(type))
        //     {
        //         arraySize++;
        //     }
        // }

        // int index = 0;
        // Pokemon[] result = new Pokemon[arraySize];
        // foreach (Pokemon pokemon in pokemons)
        // {
        //     if (pokemon != null && pokemon.Type.HasFlag(type))
        //     {
        //         result[index++] = pokemon;
        //     }
        // }

        // return result;
        return null;
    }

    public void Save(StreamWriter file)
    {
        throw new NotImplementedException();
        // foreach (ICollectible pokemon in pokemons)
        // {
        //     if (pokemon != null)
        //     {
        //         file.WriteLine(pokemon.ToString());
        //     }
        // }
    }

    public PokedexDto ToDto()
    {
        throw new NotImplementedException();
        // return new PokedexDto
        // {
        //     // On converti tous les pokémons en leur version DTO
        //     Pokemons = pokemons
        //         .Where(p => p != null)
        //         .Select(p => p.ToDto())
        //         .ToArray()
        // };
    }

    public int Count
    {
        get
        {
            return collectibles.Count(p => p != null);
        }
    }
}

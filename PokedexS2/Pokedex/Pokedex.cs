// https://www.pokepedia.fr/Liste_des_Pok%C3%A9mon_dans_l%27ordre_du_Pok%C3%A9dex_National
namespace Pokedex;

public class Pokedex
{
    Pokemon[] pokemons = new Pokemon[151];

    public Pokedex()
    {
    }

    public Pokedex(PokedexDto pokedexDto)
    {
        LoadDto(pokedexDto);
    }

    public void LoadDto(PokedexDto pokedexDto)
    {
        foreach (PokemonDto pokemonDto in pokedexDto.Pokemons)
        {
            Pokemon pokemon = new Pokemon(pokemonDto);
            pokemons[pokemon.Id] = pokemon;
        }
    }

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
        foreach (Pokemon pokemon in pokemons)
        {
            if (pokemon != null && pokemon.Type.HasFlag(type))
            {
                arraySize++;
            }
        }

        int index = 0;
        Pokemon[] result = new Pokemon[arraySize];
        foreach (Pokemon pokemon in pokemons)
        {
            if (pokemon != null && pokemon.Type.HasFlag(type))
            {
                result[index++] = pokemon;
            }
        }

        return result;
    }

    public void Save(StreamWriter file)
    {
        foreach (Pokemon pokemon in pokemons)
        {
            if (pokemon != null)
            {
                file.WriteLine(pokemon.ToString());
            }
        }
    }

    public PokedexDto ToDto()
    {
        return new PokedexDto
        {
            // On converti tous les pokémons en leur version DTO
            Pokemons = pokemons
                .Where(p => p != null)
                .Select(p => p.ToDto())
                .ToArray()
        };
    }
}

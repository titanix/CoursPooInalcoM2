using Pokedex;
namespace Tests;

public class PokedexTests
{
    [Fact]
    public void AddMonsterTest()
    {
        // Arrange
        Pokemon pokemon = new Pokemon(1, "Bulbizarre", Type.Grass);
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex(); // Pokedex.Pokedex car Pokedex est à la fois un namespace et une class

        // Act
        pokedex.Add(pokemon);

        // Assert
        Assert.Equal<int>(1, pokedex.Count);
    }  
    
    [Fact]
    public void GetMonsterTest()
    {
        // Arrange
        Pokemon pokemon = new Pokemon(1, "Bulbizarre", Type.Grass);
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex(); // Pokedex.Pokedex car Pokedex est à la fois un namespace et une class
        pokedex.Add(pokemon);

        // Act
        Pokemon pred = pokedex.Get(1);

        // Assert
        Assert.Equal<Pokemon>(pokemon, pred);
    }  

    [Fact]
    public void DiscoverMonstreTest()
    {
        // Arrange
        Pokemon pokemon = new Pokemon(1, "Bulbizarre", Type.Grass, false);
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex();
        pokedex.Add(pokemon);

        // Act
        pokedex.Discover(pokemon);

        // Assert
        Assert.True(pokedex.Get(1).Discovered);
    }

    [Fact]
    public void GetByNameTest()
    {
        // Arrange
        Pokemon pokemon = new Pokemon(1, "Bulbizarre", Type.Grass, false);
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex();
        pokedex.Add(pokemon);

        // Act
        Pokemon p = pokedex.GetByName("Bulbizarre");

        // Assert
        Assert.Equal<Pokemon>(pokemon, p);

        // Act 2: Récupérer un Pokémon avec un nom null
        Pokemon nullPokemon = pokedex.GetByName("null");

        // Assert 2: Vérifier que le résultat est null
        Assert.Null(nullPokemon);
    }

    [Fact]
    public void GetByTypeTest()
    {
        // Arrange
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex();
        Pokemon pokemon1 = new Pokemon(1, "Bulbizarre", Type.Grass, false);
        Pokemon pokemon2 = new Pokemon(2, "Herbizarre", Type.Grass, false);
        Pokemon pokemon4 = new Pokemon(3, "Florizarre", Type.Grass | Type.Poison, false);
        Pokemon pokemon3 = new Pokemon(4, "Salamèche", Type.Fire, false);
        pokedex.Add(pokemon1);
        pokedex.Add(pokemon2);
        pokedex.Add(pokemon3);
        pokedex.Add(pokemon4);

        // Act
        Pokemon[] pokedex_filtre = pokedex.GetByType(Type.Grass);

        // Assert
        Assert.Equal<int>(3, pokedex_filtre.Length);

        // Vérifier que les Pokémon filtrés sont bien ceux attendus
        Assert.Collection(pokedex_filtre,
            p => Assert.Equal("Bulbizarre", p.Name),
            p => Assert.Equal("Herbizarre", p.Name),
            p => Assert.Equal("Florizarre", p.Name)
        );
    }

    [Fact]
    public void CommandNotFoundTest()
    {
        CommandInterpreter cmdInt = new CommandInterpreter(null, null);
        Assert.Throws<CommandNotFoundException>(() => cmdInt.Interpret(new string[] {"abc", "def", "ghi"}));
    }

}
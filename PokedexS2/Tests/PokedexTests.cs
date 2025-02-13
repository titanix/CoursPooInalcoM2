using Pokedex;

namespace Tests;


public class PokedexTests
{
    [Fact]
    public void AddMonsterTest()
    {
        // Arrange
        Pokemon pokemon = new Pokemon(1, "Bulbizarre", Type.Grass);
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex(); // Pokedex.Pokedex car Pokedex est à la fois un namespace et une classe

        // Act
        pokedex.Add(pokemon);

        // Assert
        Assert.Equal<int>(1, pokedex.Count); // (valeur attendue, valeur test)
    }

    [Fact]
    public void GetMonsterTest()
    {
        // Arrange
        Pokemon pokemon = new Pokemon(1, "Bulbizarre", Type.Grass);
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex();

        // Act
        pokedex.Add(pokemon);

        // Assert
        Assert.Equal<Pokemon>(pokemon, pokedex.Get("Bulbizarre"));
    }

    [Fact]
    public void DiscoverMonsterTest()
    {
        // Arrange
        Pokemon pokemon = new Pokemon(1, "Bulbizarre", Type.Grass);
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex(); 

        // Act
        pokedex.Add(pokemon);
        pokedex.Discover(pokemon);

        // Assert
        Assert.True(pokemon.Discovered);
    }
}
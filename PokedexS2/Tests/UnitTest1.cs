using Pokedex;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void AddMonsterTest()
    {
        // Arrange
        Pokemon pokemon = new Pokemon(25, "Picachu", Type.Electric);
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex();
        
        // Act
        pokedex.Add(pokemon);

        // Assert
        Assert.Equal(1, pokedex.Count);
    }

    [Fact]
    public void DiscoverMonsterTest()
    {
        // Arrange
        Pokemon pokemon = new Pokemon(25, "Picachu", Type.Electric);
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex();
        pokedex.Add(pokemon);

        // Act
        pokedex.Discover(pokemon);

        // Assert
        Assert.True(pokemon.Discovered);
    }

    [Fact]
    public void GetMonsterByIdTest()
    {
        // Arrange
        Pokemon pokemon = new Pokemon(25, "Picachu", Type.Electric);
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex();
        pokedex.Add(pokemon);

        // Action
        Pokemon result = pokedex.Get(25);

        // Assert
        Assert.Equal(pokemon, result);
    }

    [Fact]
    public void GetMonsterByNameTest()
    {
        // Arrange
        Pokemon pokemon = new Pokemon(25, "Picachu", Type.Electric);
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex();
        pokedex.Add(pokemon);

        // Action
        Pokemon result = pokedex.Get("Picachu");

        // Assert
        Assert.Equal(pokemon, result);
    }
}
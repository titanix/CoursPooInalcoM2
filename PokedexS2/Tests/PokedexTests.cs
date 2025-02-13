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
        Assert.Equal<Pokemon>(pred, pokemon);
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
        Assert.Equal<bool>(pokedex.Get(1).Discovered, true);
    }

    [Fact]
    public void GetByNameTest()
    {
        // Arrange
        Pokemon pokemon = new Pokemon(1, "Bulbizarre", Type.Grass, false);
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex();
        pokedex.Add(pokemon);

        // Act
        Pokemon p = pokedex.Get("Bulbizarre");

        // Assert
        Assert.Equal<Pokemon>(p, pokemon);
    }

    [Fact]
    public void GetByTypeTest()
    {
        // Arrange
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex();
        Pokemon pokemon1 = new Pokemon(1, "Bulbizarre", Type.Grass, false);
        Pokemon pokemon2 = new Pokemon(2, "Herbizarre", Type.Grass, false);
        Pokemon pokemon3 = new Pokemon(4, "Salamèche", Type.Fire, false);
        pokedex.Add(pokemon1);
        pokedex.Add(pokemon2);
        pokedex.Add(pokemon3);

        // Act
        Pokemon[] pokedex_filtre = pokedex.GetByType(Type.Grass);

        // Assert
        Assert.Equal<int>(2, pokedex_filtre.Length);
        Pokemon p1 = pokedex_filtre[0];
        Assert.Equal<Pokemon>(p1, pokemon1);
        Pokemon p2 = pokedex_filtre[1];
        Assert.Equal<Pokemon>(p2, pokemon2);
    }

}
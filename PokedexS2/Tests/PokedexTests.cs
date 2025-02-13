using Pokedex;

namespace Tests;

public class PokedexTests
{
    [Fact]
    public void AddMonsterTest()
    {
        //Arrange
        Pokemon pokemon = new Pokemon(1, "Bulbizarre", Type.Grass); 
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex();

        //Act
        pokedex.Add(pokemon);

        //Assert
        Assert.Equal(1, pokedex.Count);
    }

    [Fact]
    public void GetPokemonById()
    {
        // Arrange
        Pokemon pokemon = new Pokemon(1, "Bulbizarre", Type.Grass); 
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex();
        pokedex.Add(pokemon);

        // Act
        var result = pokedex.Get(1);

        // Assert
        Assert.Equal(pokemon, result);
    }


    [Fact]
    public void GetPokemonByType()
    {
        // Arrange
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex();
        Pokemon pokemon = new Pokemon(1, "Bulbizarre", Type.Grass); 
        pokedex.Add(pokemon);

        // Act
        var result = pokedex.GetByType(Type.Grass);

        // Assert
        Assert.Single(result); // single来判断是否只含有一个元素
        Assert.Contains(pokemon, result);
    }
}
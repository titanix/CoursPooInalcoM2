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

}
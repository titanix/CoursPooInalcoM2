using Pokedex;

namespace Tests;

public class PokedexTests
{
    [Fact]
    public void AddMonsterTest()
    {
        // Arrange
        Pokemon pokemon = new Pokemon(1, "Bulbizarre", Type.Grass);
        Pokedex.Pokedex pokedex = new Pokedex.Pokedex();

        // Act
        pokedex.Add(pokemon);

        // Assert
        Assert.Equal(1, pokedex.Count);
    }

    [Fact]
    public void CommandNotFoundTest()
    {
        CommandInterpreter cmdInt = new CommandInterpreter(null, null);

        Assert.Throws<CommandNotFoundException>(() => cmdInt.Interpret(new string[] { "pzrfjoi" } ));
    }
}
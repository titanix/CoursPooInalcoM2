namespace Tests;

public class AbsTests // Cherche toutes les classes publiques
{
    [Fact]
    public void AbsNegTest()
    {
        // Arrange
        int n = -1;
        int expected = 1;

        // Act
        int result = Maths.Abs(n);

        // Assert
        Assert.Equal<int>(expected, result);

    }

    [Fact]
    public void AbsPosTest()
    {
        // Arrange
        int n = 1;
        int expected = 1;

        // Act
        int result = Maths.Abs(n);

        // Assert
        Assert.Equal<int>(expected, result);

    }

    [Fact]
    public void AbsZeroTest()
    {
        // Act
        int result = Maths.Abs(0);

        // Assert
        Assert.Equal<int>(0, result);

    }

    [Fact]
    public void AbsBigNumTest()
    {
        // Act
        int result = Maths.Abs(5390183);

        // Assert
        Assert.Equal<int>(5390183, result);

    }
}

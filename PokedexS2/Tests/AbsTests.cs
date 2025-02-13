namespace Tests;

public class AbsTests // Cherche toutes les classes publiques
{
    [Fact]
    public void TestAbsNegative()
    {
        // Arrange
        int input = -1;
        int label = 1;

        // Act
        int pred = Maths.Abs(input);

        // Assert
        Assert.Equal<int>(pred, label);
    }

    [Fact]
    public void TestAbsZero()
    {
        // Arrange
        int input = 0;
        int label = 0;

        // Act
        int pred = Maths.Abs(input);

        // Assert
        Assert.Equal<int>(pred, label);
    }

    [Fact]
    public void TestAbsPositive()
    {
        // Arrange
        int label = 1;
        int input = 1;

        // Act
        int pred = Maths.Abs(input);

        // Assert
        Assert.Equal<int>(pred, label);
    }

    [Fact]
    public void TestMaxInt()
    {
        // Arrange
        int input = int.MaxValue;
        int label = int.MaxValue;

        // Act
        int pred = Maths.Abs(input);

        // Assert
        Assert.Equal<int>(pred, label);
    }

    [Fact]
    public void TestMinInt()
    {
        // Arrange
        int input = int.MinValue;
        int label = int.MinValue;

        // Act
        int pred = Maths.Abs(input);

        // Assert
        Assert.Equal<int>(pred, label);
    }
}
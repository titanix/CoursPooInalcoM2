namespace Tests;

public class AbsTests
{
    [Fact]
    public void TestAbsPositive()
    {
        int result = Math.Abs(1);

        Assert.Equal(1, result);
    }

    [Fact]
    public void TestAbsNegative()
    {
        int result = Math.Abs(-1);

        Assert.Equal(1, result);
    }

    [Fact]
    public void TestAbsZero()
    {
        int result = Math.Abs(0);

        Assert.Equal(0, result);
    }
}
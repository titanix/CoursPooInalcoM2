namespace Tests;

public static class Maths
{
    public static int Abs(int n)
    {
        if (n < 0)
        {
            n *= -1;
        }
        return n;
    }
}
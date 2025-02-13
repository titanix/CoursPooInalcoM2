public static class Maths
{
    public static int Abs(int n)
    {
        if (n < 0)
        {
            n = n * -1;
        }
        return n;

        // return n < 0 ? -n : n;
    }
}
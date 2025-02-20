public static class Maths
{
    public static int Abs(int n)
    {
        return (n + (n >> 31)) ^ (n >> 31);
    }
}
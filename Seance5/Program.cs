Rectangle rectangle = new Rectangle(2, 4);
Console.WriteLine(rectangle.Surface);

// on ne peut pas modifier la surface !
//rectangle.Surface = 5; // erreur de compilation

Console.WriteLine(rectangle.Longueur);
rectangle.Longueur = 10;

struct Rectangle
{
    int longueur;

    // propriété avec back-field (longueur juste au-dessus)
    public int Longueur
    {
        get
        {
            Console.WriteLine("get de Longueur appelé");

            return longueur;
        }

        set
        {
            Console.WriteLine("set de Longueur appelé");

            longueur = value;
        }
    }

    // propriété auto-implémentée, en lecture seule
    public int Largeur { get; private set; }

    // propriété calculée
    public int Surface
    {
        get
        {
            return Longueur * Largeur;
        }
    }

    public Rectangle(int longueur, int largeur)
    {
        Longueur = longueur;
        Largeur = largeur;
    }
}
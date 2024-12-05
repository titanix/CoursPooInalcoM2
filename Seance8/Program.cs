using Pokedex;

public class Program
{
    public static void Main(string[] args)
    {
        Program p = new Program();

        int[] tableau = new int[] { 1, 2, 3, 4, 5 };

        // Le type Func permet de représenter une méthode
        // C'est un type générique qui prend pour arguments paramétrique (entre <>) la signature de la fonction a stocker
        // Par exemple pour une méthode string AddDisplay(int a, int b)
        // On a Func<int, int, string>
        // Les deux premiers arguments correspondent à ceux de la fonction et le dernier au type de retour
        // ici on fournit la méthode DOubler de la classe Program
        Func<int, int> mathOp = p.Doubler;

        // Même principe que plus haut mais on déclare le contenu de la variable à partir d'une fonction anonyme
        // Les fonctions anonymes sont aussi appelées lambda
        // La syntaxte des lambda est abrégée : pas forcément de type des paramères, 'return' implicite
        Func<int, int> lambda = (int PARAM) => PARAM * 2;

        // Ici, le code de la fonction anonyme est plus long, on utilise donc un bloc (accolades) et un 'return'
        Func<int, int> funcPrint = i => 
        {
            Console.Write(i + " ");
            return i;
        };

        // La méthode Select prend une fonction qui a partir d'un élément d'un certain type renvoie un élément du même type
        // ToArray est nécessaire pour demander l'exécution des Select et Where
        // C'est un exemple d'utilisation de la technologie Linq
        int[] tableauDoublé = tableau
            .Select(lambda)
            .Select(e => e * 2)
            .Select(lambda)
            .Select(funcPrint)
            .ToArray();

        Pokemon[] pokemons = new Pokemon[] {
            new Pokemon(1, "Pikachu", Type.Normal),
            null,
            null,
            new Pokemon(4, "Raichu", Type.Normal),
            null
        };


Console.WriteLine();
        pokemons
            //.Select(p => { Console.Write($"[{p}]"); return p; })
            .Where(p => p != null)
            .Select(p => p.Name)
            .Select(nom => { Console.Write($"[{nom}]"); return nom; })
            .ToArray()
            ;
    }

    int Doubler(int a)
    {
        return a * 2;
    }

    void Demo()
    {
        int result_1 = CalculGenerique(2, 3, Addition);
        Console.WriteLine($"add 2, 3 : {result_1}");

        int result_2 = CalculGenerique(2, 3, Multiplication);
        Console.WriteLine($"mult 2, 3 : {result_2}");
    }

    int CalculGenerique(int a, int b, Func<int, int, int> operation)
    {
        return operation(a, b);
    }

    int Addition(int a, int b)
    {
        return a + b;
    }

    int Multiplication(int a, int b)
    {
        return a * b;
    }
}

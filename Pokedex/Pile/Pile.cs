/*
    Seconde implémentation. Ne gère que les entiers.
    Cette classe utilise une méthode privée afin de limiter le code dupliquée.
*/
public class Pile
{
    int[] array = new int[0];

    public void Push(int element)
    {
        int[] newArray = CopyArray(1);

        // mettre le nouvel élément sur la pile
        newArray[array.Length] = element;
        
        // réaffecter l'ancien tableau
        array = newArray;
    }

    public int Pop()
    {
        int[] newArray = CopyArray(-1);

        // stocker le résultat final
        int result = array[array.Length - 1];
        // réaffectation
        array = newArray;

        // retourne le dernier élément
        return result;
    }

    int[] CopyArray(int value)
    {
        int[] newArray = new int[array.Length + value];
        int size = Math.Min(array.Length, newArray.Length);     
        for (int i = 0; i < size ; i++)
        {
            newArray[i] = array[i];
        }

        return newArray;
    }

    public void PrintStack()
    {
        Console.WriteLine("--- stack bottom ---");
        foreach (int element in array)
        {
            Console.WriteLine(element);
        }
        Console.WriteLine("---  stack top   ---");
    }
}
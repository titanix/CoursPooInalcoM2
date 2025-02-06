/*
    Première pile implémentée. Ne gère que les entiers.
*/
public class AnciennePile
{
    int[] array = new int[0];

    public void Push(int element)
    {
        // changement de taille du tableau
        int newSize = array.Length + 1;

        // créer un nouveau tableau
        int[] newArray = new int[newSize];

        // copier les anciens éléments dans le nouveau tableau
        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }

        // mettre le nouvel élément sur la pile
        newArray[array.Length] = element;
        
        // réaffecter l'ancien tableau
        array = newArray;
    }

    public int Pop()
    {
        // créer un nouveau tableau de taille -1
        int[] newArray = new int[array.Length - 1];
        // copier les éléments du tableau actuel vers le nouveau

        for (int i = 0; i < newArray.Length; i++)
        {
            newArray[i] = array[i];
        }

        // stocker le résultat final
        int result = array[array.Length - 1];
        // réaffectation
        array = newArray;

        // retourne le dernier élément
        return result;
    }

    public void PrintStack()
    {
        // for, foreach
        Console.WriteLine("--- stack bottom ---");
        foreach (int element in array)
        {
            Console.WriteLine(element);
        }
        Console.WriteLine("---  stack top   ---");
    }
}
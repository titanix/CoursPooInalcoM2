/*
    Pile générique. Celle-ci peut contenir des éléments de n'importe quel type.
    S'instancie de la façon suivante, par exemple pour des chaînes de caractères : 
    Pile<string> pile = new Pile<string>();
*/
public class Pile<T>
{
    T[] array = new T[0];

    public int Count {
        get
        {
            return array.Length;
        }
    }

    public void Push(T element)
    {
        T[] newArray = CopyArray(1);

        // mettre le nouvel élément sur la pile
        newArray[array.Length] = element;

        // réaffecter l'ancien tableau
        array = newArray;
    }

    public T Pop()
    {
        T[] newArray = CopyArray(-1);

        // stocker le résultat final
        T result = array[array.Length - 1];
        // réaffectation
        array = newArray;

        // retourne le dernier élément
        return result;
    }

    T[] CopyArray(int value)
    {
        T[] newArray = new T[array.Length + value];
        int size = Math.Min(array.Length, newArray.Length);     
        for (int i = 0; i < size ; i++)
        {
            newArray[i] = array[i];
        }

        return newArray;
    }

    public void PrintStack()
    {
        // for, foreach
        Console.WriteLine("--- stack bottom ---");
        foreach (T element in array)
        {
            Console.WriteLine(element);
        }
        Console.WriteLine("---  stack top   ---");
    }
}
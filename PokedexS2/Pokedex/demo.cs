using Pokedex;

public interface IDemo // Convention : commencer par 'I', interface de qqch
{
    void Print();

    int Count {get;}

    int NbCalls { get; set; }

    string Test(string plop, Pokemon p);
}

// class Demo est héritée de IDemo
public class Demo : IDemo // class Demo doit se conformer à l'interface IDemo
{
    public int Count => throw new NotImplementedException();

    public int NbCalls { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Print()
    {
        throw new NotImplementedException();
    }

    public string Test(string plop, Pokemon p)
    {
        throw new NotImplementedException();
    }
}
namespace Pokedex;

public abstract class Command
{
    protected Pokedex Pokedex;
    protected bool isValid = true;
    protected string[] arguments;

    public Command() { }

    public Command(Pokedex pokedex, string[] commandArguments)
    {
        Pokedex = pokedex;
        arguments = commandArguments;
    }

    public abstract void Execute();

}
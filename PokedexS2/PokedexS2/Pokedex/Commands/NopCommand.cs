namespace Pokedex;

// Commande qui ne fait rien
public class NopCommand : Command
{
    public NopCommand()
    {
    }

    public override void Execute()
    {
        // ne fait rien
    }
}
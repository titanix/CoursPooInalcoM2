namespace Pokedex;
// Affiche le nombre de pokémon contenu dans le pokedex
public class ChangeLanguageCommand : Command
{
    LocalizationService localizationService;
    string newLang;

    public ChangeLanguageCommand(Pokedex pokedex, LocalizationService  localizationService, string[] commandArguments)
        : base(pokedex, commandArguments)
    {
        this.localizationService = localizationService;
        // TODO: faire de la validation
        // nombre d'argument
        // et format : à savoir chaîne de deux lettres
        newLang = commandArguments[0];
    }

    public override void Execute()
    {
        localizationService.ChangeLanguage(newLang);
    }
}
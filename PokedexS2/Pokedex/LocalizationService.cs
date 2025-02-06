using System.Globalization;

namespace Pokedex;

public class LocalizationService
{
    Dictionary<string, Dictionary<string, string>> data;
    string currentLanguage;

    public LocalizationService()
    {
        currentLanguage = CultureInfo.CurrentCulture.Name.Split("-")[0];

        // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer
        data = new Dictionary<string, Dictionary<string, string>>()
        {
            { "fr" , new Dictionary<string, string>()
                {
                    { "msg.FileLoaded", "Fichier chargé." },
                    // traduire les noms localizés en type de commande
                    { "ajouter", "add" },
                    { "chercher", "search" }
                }
            },
            { "en" , new Dictionary<string, string>()
                {
                    { "msg.FileLoaded", "File loaded." },
                    { "add", "add" },
                    { "search", "search" }
                }
            }
        };
    }

    public string GetText(string key)
    {
        return data[currentLanguage][key];
    }

    public void ChangeLanguage(string lang)
    {
        //CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
        currentLanguage = lang;
    }
}
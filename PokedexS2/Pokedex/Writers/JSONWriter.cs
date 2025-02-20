// using System.Text.Encodings.Web;
// using System.Text.Json;
// using System.Text.Unicode;

// namespace Pokedex;
// // Toutes les méthodes et propriétés de l'interface doivent être implémentées dans la classe qui l'implémente
// // Tout doit être public dans une interface

// public class JsonWriter : IWriter // JsonWriter est de type IWriter
// {

//     // Sauvegarde le Pokedex sous forme de fichier JSON dont le nom est passé en paramètre
//     public bool SaveFile(string path, Pokedex pokedex)
//     {
//         try
//         {
//             string content = GetJson(pokedex);
//             File.WriteAllText(path, content);
//         }
//         catch
//         {
//             Console.Error.WriteLine("An error occured while saving the file");
//         }

//         return true;
//     }


//     public string GetJson(Pokedex pokedex)
//     {
//         // Configuration des options de sérialisation JSON
//         JsonSerializerOptions options = new JsonSerializerOptions
//         {
//             WriteIndented = true,
//             // On suppose que JsonNamingPolicy.SnakeCaseLower est une implémentation personnalisée
//             PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
//             // Pour éviter que le sérialiseur n'échappe les caractères non-ASCII (ex : Salamèche)
//             Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement)
//         };

//         PokedexDto pokedexDto = pokedex.ToDto();
//         string jsonString = JsonSerializer.Serialize(pokedexDto, options);

//         return jsonString;
//     }
// }

// public class TextWriter : IWriter
// {
//     public bool SaveFile(string path, Pokedex pokedex)
//     {
//         return true;
//     }
// }

// public interface IWriter
// {
//     bool SaveFile(string path, Pokedex pokedex);
// }
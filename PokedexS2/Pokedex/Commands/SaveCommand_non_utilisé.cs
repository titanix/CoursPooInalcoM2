// namespace Pokedex;

// // save <fichier>
// public class SaveCommand : Command
// {
//     string saveDirecty = "Data";

//     public SaveCommand(Pokedex pokedex, string[] commandArguments)
//         : base(pokedex, commandArguments)
//     {
//         if (commandArguments.Length < 1)
//         {
//             isValid = false;
//         }
//     }

//     public override void Execute()
//     {
//         if (!isValid)
//         {
//             Console.Error.WriteLine("Il manque le chemin du fichier.");
//             return;
//         }

//         string path = AddExtension(arguments[0]);
//         path = $"{saveDirecty}/{path}";
//         Directory.CreateDirectory(saveDirecty);

//         Iwriter txtWriter = new TxtWriter();
//         txtWriter.SaveFile(path, Pokedex);
//         // StreamWriter streamWriter = new StreamWriter(path);

//         // SavePokedex(streamWriter);
//         // streamWriter.Flush();
//         // streamWriter.Close();

//         // Console.WriteLine($"Pokedex saved to file {path}");
//     }

//     void SavePokedex(StreamWriter file)
//     {
//         Pokedex.Save(file);
//     }

//     string AddExtension(string path)
//     {
//         if (!path.Contains("."))
//         {
//             return $"{path}.csv";
//         }

//         return path;
//     }
// }
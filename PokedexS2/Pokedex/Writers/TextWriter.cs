// namespace Pokedex;

// public class TextWriter : IWriter
// {
//     public bool SaveFile(string fileName, Pokedex pokedex)
//     {
//         StreamWriter streamWriter = new StreamWriter(fileName);

//         pokedex.Save(streamWriter);
//         streamWriter.Flush();
//         streamWriter.Close();

//         Console.WriteLine($"Pokedex saved to file {fileName}");

//         return true;
//     }
    
// }

// public interface IWriter
// {
//     bool SaveFile(string fileName, Pokedex pokedex);
// }


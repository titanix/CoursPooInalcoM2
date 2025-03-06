using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Pokedex
{
    public class UnifiedWriter : IWriter
    {
        private object writer;

        public UnifiedWriter(string writerType)
        {
            if (writerType.Equals("TextWriter", StringComparison.OrdinalIgnoreCase))
            {
                writer = new TextWriter();
            }
            else if (writerType.Equals("JsonWriter", StringComparison.OrdinalIgnoreCase))
            {
                writer = new JsonWriter();
            }
            else
            {
                throw new ArgumentException("Invalid writer type.");
            }
        }

        public bool SaveFile(Pokedex pokedex, string path)
        {
            var saveFileMethod = writer.GetType().GetMethod("SaveFile");
            if (saveFileMethod != null)
            {
                return (bool)saveFileMethod.Invoke(writer, new object[] { pokedex, path });
            }

            return false;
        }

        public string GetJson(string path)
        {
            var getJsonMethod = writer.GetType().GetMethod("GetJson");
            if (getJsonMethod != null)
            {
                return (string)getJsonMethod.Invoke(writer, new object[] { path });
            }

            return string.Empty;
        }
    }

    public class TextWriter : IWriter
    {
        string saveDirecty = "Data";

        public bool SaveFile(Pokedex pokedex, string path)
        {
            try
            {
                path = $"{saveDirecty}/{AddExtension(path)}";
                Directory.CreateDirectory(saveDirecty);

                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    pokedex.Save(streamWriter);
                    streamWriter.Flush();
                }

                Console.WriteLine($"Pokedex saved to file {path}");
            }
            catch
            {
                Console.Error.WriteLine("Error saving pokedex to file");
                return false;
            }

            return true;
        }

        public string GetJson(string path)
        {
            throw new NotImplementedException();
        }

        private string AddExtension(string path)
        {
            if (!path.Contains("."))
            {
                return $"{path}.csv";
            }

            return path;
        }
    }

    public class JsonWriter : IWriter
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement),
        };

        public bool SaveFile(Pokedex pokedex, string path)
        {
            try
            {
                PokedexDto pokedexDto = pokedex.ToDto();
                string jsonString = JsonSerializer.Serialize(pokedexDto, options);
                File.WriteAllText(path, jsonString);
            }
            catch
            {
                Console.Error.WriteLine("Erreur lors de la sauvegarde du fichier");
                return false;
            }

            return true;
        }

        public string GetJson(string path)
        {
            string content = File.ReadAllText(path);
            return content;
        }
    }
}
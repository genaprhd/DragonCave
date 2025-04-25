using Newtonsoft.Json;
namespace DragonCave.DB;

public class LoadFromDB
{
        public static Character LoadPrefab(string filepath, string name)
    {
        if (!File.Exists(filepath))
        {
            Console.WriteLine($"File not found: {filepath}");
            return null;
        }
            var json = File.ReadAllText(filepath);
            var characters = JsonConvert.DeserializeObject<List<Character>>(json);
            if (characters == null || characters.Count == 0)
            {
                Console.WriteLine("No characters found in JSON file.");
                return null;
            }
            var character = characters.FirstOrDefault(c => c.Name == name);
            return character;
        }
    public static Character LoadCreature(string filepath, string name)
    {

        if (!File.Exists(filepath))
        {
            throw new FileNotFoundException($"File not found: {filepath}");
        }

        var json = File.ReadAllText(filepath);
        if (string.IsNullOrEmpty(json))
        {
            throw new InvalidOperationException("File is empty or contains invalid JSON.");
        }
        List<Character> characters = JsonConvert.DeserializeObject<List<Character>>(json);

        if (characters == null || characters.Count == 0)
        {
            Console.WriteLine("No characters found in JSON file.");
            throw new InvalidOperationException("No characters found in JSON file.");
        }
        var character = characters.FirstOrDefault(c => c.Name == $"{name}");
        return character;
    }
}

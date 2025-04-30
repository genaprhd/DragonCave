using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DragonCave.DB;

public class JSONBase
{
        public static Character? LoadPrefab(string filepath, string name)
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
    private static void EnsureFileExists(string filepath){
        if(!string.IsNullOrEmpty(filepath) && !Directory.Exists(Path.GetDirectoryName(filepath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filepath));
        }
        if (!File.Exists(filepath))
        {
            File.WriteAllText(filepath, "[]");
        }
    }
    public static List<Character> LoadAll()
    {
        string filepath = Path.Combine(AppContext.BaseDirectory, "DB", "PlayerChars.json");
        EnsureFileExists(filepath);
        var json = File.ReadAllText(filepath);
        var list = JsonConvert.DeserializeObject<List<Character>>(json);
        return list ?? new List<Character>();
    }
    public static bool Add(Character character)
    {
        var PlayerChars = LoadAll();
        if (PlayerChars.Count >= 3){
            Console.WriteLine("You have reached the maximum number of characters.");
            return false;
        }
        PlayerChars.Add(character);
        SaveAll(PlayerChars);
        return true;
    }
    private static void SaveAll(List<Character> characters)
    {
        var settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            Converters = [new StringEnumConverter()]
    };
        var json = JsonConvert.SerializeObject(characters, settings);
        File.WriteAllText(Path.Combine(AppContext.BaseDirectory, "DB", "PlayerChars.json"), json);
    }
    public static string [] GetAllNames(){
        var players = LoadAll();
        return players
            .Select(p => p.Name)
            .ToArray();
    }
    public static Character LoadPlayer(int index)
    {
        var players = LoadAll();
        if (index < 0 || index >= players.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        return players[index];
    }
    public static bool IfAnyPlayerSaved(){
        var players = LoadAll();
        if (players.Count == 0)
        {
            return false;
        }
        return true;
    }
}
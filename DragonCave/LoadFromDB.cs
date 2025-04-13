using Newtonsoft.Json;
namespace DragonCave.DB;

public class LoadFromDB
{
    public static Character LoadCreature(string filepath,  string name)
    {
        if (!File.Exists(filepath))
        {
            Console.WriteLine($"File not found: {filepath}");
            return null;
        }
        var json = File.ReadAllText(filepath);
        List<Character> characters = JsonConvert.DeserializeObject<List<Character>>(json);

        if (characters == null || characters.Count == 0)
        {
            Console.WriteLine("No characters found in JSON file.");
            return null;
        }
        var character = characters.FirstOrDefault(c => c.Name == $"{name}");
        return character;
    }
}
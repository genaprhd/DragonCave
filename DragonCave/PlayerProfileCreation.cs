using Newtonsoft.Json;

namespace DragonCave;

public class PlayerProfileCreation
{
    public static Character CreateProfile()
    {
        Console.WriteLine("Lets create your character!");

        var baseCharacter = LoadPrefab("/Users/genaprhd/VSCode/DragonCave/DragonCave/DB/Creatures.json");

        if (baseCharacter == null)
        {
            Console.WriteLine("Failed to load base character. Exiting profile creation.");
            return null;
        }
        Console.WriteLine($"Base character loaded: {baseCharacter.Name}, {baseCharacter.CharRace}");
        // Create a new character using the base character's properties
        string Name = baseCharacter.Name;
        string CharRace = baseCharacter.CharRace;
        var Player = new Character.CharacterBuilder(Name, CharRace)
            .WithName(baseCharacter.Name)
            .WithCharRace(baseCharacter.CharRace)
            .WithStats(baseCharacter.Stats)
            .WithCombatStats(baseCharacter.CombatStats)
            .AsBot(baseCharacter.IsBot)
            .WithStatus(baseCharacter.Status)
            .WithExperience(baseCharacter.Experience)
            .WithRarity(baseCharacter.Rarity)
            .Build();
        
        Player.Name = GetCharacterName();
        Player.CharRace = GetCharacterRace();        
        Player.Stats = GetPlayerStats();
        Player.CombatStats = CalcCombatStats(Player.Stats);

        Console.WriteLine($"You created a new player profile named {Player.Name}, {Player.CharRace}!");
        return Player;
    }

    private static Character LoadPrefab(string filepath)
    {
        Console.WriteLine($"Loading character from {filepath}");
        if (!File.Exists(filepath))
        {
            Console.WriteLine($"File not found: {filepath}");
            return null;
        }
        try
        {
            var json = File.ReadAllText(filepath);
            Console.WriteLine($"Reading file: {filepath}");
            List<Character> characters = JsonConvert.DeserializeObject<List<Character>>(json);
                if (characters == null || characters.Count == 0)
                    {
                        Console.WriteLine("No characters found in JSON file.");
                        return null;
                    }
        var character = characters.FirstOrDefault(c => c.Name == "Noname");
        return character.Name == "Noname" ? character : null;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error deserializing JSON: {ex.Message}");
            return null;
        }
    }
    private static string GetCharacterName()
    {
        int tryNum = 0;
        string name = "";
        Console.WriteLine("Name yourself, mortal.");
        while (true)
        {
            tryNum++;
            if (tryNum > 1)
            {
                Console.WriteLine("Give me correct Name!");
            }

            name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                return name;
            }
        }
    }

    private static string GetCharacterRace()
    {    //Future place for code
        return "A";
    }

    private static Stats GetPlayerStats()
    {
        Stats playerStats = new Stats(10, 10, 10);
        return playerStats;
    }

    private static CombatStats CalcCombatStats(Stats stats)
    {
        CombatStats playerCombatStats = new CombatStats(1, 2, 3, 4, 5);
        return playerCombatStats;
    }

}
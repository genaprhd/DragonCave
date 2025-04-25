using DragonCave.DB;
using Newtonsoft.Json;

namespace DragonCave;

public class PlayerProfileCreation
{
    public static Character CreateProfile()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "DB", "Creatures.json");

        Console.WriteLine("Lets create your character!");
        var baseCharacter = LoadFromDB.LoadPrefab(path, "NoName");
        if (baseCharacter == null)
        {
            Console.WriteLine("Failed to load Character");
        }
        var Player = new Character.CharacterBuilder()
            .WithName(GetCharacterName())
            .WithCharRace(GetCharacterRace())
            .WithStats(GetPlayerStats())
            .WithCombatStats(baseCharacter.CombatStats)
            .AsBot(baseCharacter.IsBot)
            .WithStatus(baseCharacter.Statuses)
            .WithExperience(baseCharacter.Experience)
            .WithRarity(baseCharacter.Rarity)
            .Build();
        Player.CombatStats = CalcCombatStats(Player.Stats);
        Console.WriteLine(Player.ToString());
        return Player;
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
    {
        Console.WriteLine("Choose your race:");

        var races = Enum.GetValues(typeof(PlayerRaces)).Cast<PlayerRaces>().ToList();

        for (int i = 1; i < races.Count; i++)
        {
            Console.WriteLine($"{i}: {races[i]}");
        }

        while (true)
        {
            Console.Write("Enter race number: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= 0 && choice < races.Count)
            {
                PlayerRaces playerRace = (PlayerRaces)choice;
                Console.WriteLine($"You have chosen: {playerRace}, confirm? (y/n)");
                string confirm = Console.ReadLine();
                if (confirm?.ToLower() == "y")
                {
                    Console.WriteLine($"You have chosen: {playerRace}");
                    return playerRace.ToString();
                }
                else
                {
                    Console.WriteLine("Choose again.");
                }
            }
            Console.WriteLine("Invalid input. Try again.");
        }
    }   
    
    private static Stats GetPlayerStats()
    {
        Stats playerStats = new Stats(10, 10, 10);
        return playerStats;
    }

    private static CombatStats CalcCombatStats(Stats stats)
    {
        CombatStats playerCombatStats = new CombatStats(1, 2, 3, 4, 5, 6);
        return playerCombatStats;
    }
}
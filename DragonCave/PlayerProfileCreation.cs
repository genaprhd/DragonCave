using System.Diagnostics;
using DragonCave.DB;

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
        Console.Clear();
        Console.WriteLine(Player.ToString());
        return Player;
    }
    private static string GetCharacterName()
    {
        int tryNum = 0;
        string name;
        Console.WriteLine("Name yourself, mortal.");
        while (true)
        {
            tryNum++;
            if (tryNum > 1)
            {
                Console.WriteLine("Give me correct Name!");
            }
            name = Console.ReadLine();
            if (string.IsNullOrEmpty(name) || name.Length < 2 || name.Length > 20)
            {
                Console.WriteLine("Name must be between 2 and 20 characters long.");
                Console.WriteLine("Try again.");
                return GetCharacterName();
            }
            else {
                bool YesOrNo = Functions.InputConfirm($"You have chosen: {name}, confirm?");
                if (YesOrNo == false)
                {
                    Console.WriteLine("Choose again.");
                    return GetCharacterName();
                }
                else
                {
                Console.WriteLine("Success! Now, lets proceed to Race selection.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(intercept: true);
                return name;
                }
            }
        }
    }
    static int selectedIndex = 0;
    private static string GetCharacterRace()
    {
        string[] MenuItems = Functions.GetEnumValues<PlayerRaces>();
        Console.CursorVisible = false;
        selectedIndex = Menu.GetOption(MenuItems,selectedIndex);
        PlayerRaces playerRace = (PlayerRaces)selectedIndex;
        bool confirm = Functions
            .InputConfirm($"You have chosen: {playerRace}, confirm?");
        if (confirm)
        {
            Console.WriteLine($"Success! You have chosen: {playerRace}.");
            return playerRace.ToString();
        }
        else
        {
            Console.WriteLine("Choose again.");
            return GetCharacterRace();
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
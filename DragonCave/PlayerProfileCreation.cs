using System.ComponentModel.Design;
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
            bool correct = Functions.InputConfirm($"You have chosen: {name}, confirm? (y/n)");
            if (!string.IsNullOrEmpty(name) && correct && name.Length > 2 && name.Length < 20)
            {
                return name;
            }
            else {
                return GetCharacterName();
            }
            
        }
    }
    static int selectedIndex = 0;
    private static string GetCharacterRace()
    {
        string[] MenuItems = Functions.GetEnumValues<PlayerRaces>();
        Console.CursorVisible = false;
        selectedIndex = Menu.GetOption(MenuItems,selectedIndex);
        switch (selectedIndex)
        {
            case 0:
                bool confirm = Functions
                    .InputConfirm($"You have chosen: {PlayerRaces.Human}, confirm? (y/n)");
                if (confirm)
                {
                    PlayerRaces playerRace = PlayerRaces.Human;
                    Console.WriteLine($"You have chosen: {playerRace}");
                    return playerRace.ToString();
                }
                else
                {
                    Console.WriteLine("Choose again.");
                    return GetCharacterRace();
                }
            case 1:
                Console.WriteLine("You have chosen: Elf");
                break;
            case 2:
                Console.WriteLine("You have chosen: Dwarf");
                break;
            case 3:
                Console.WriteLine("You have chosen: Orc");
                break;
        }
        return MenuItems[selectedIndex];
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
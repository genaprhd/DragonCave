using DragonCave.DB;

namespace DragonCave;

public class PlayerProfileCreation
{
    public static Character CreateProfile()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "DB", "Creatures.json");
        Console.WriteLine("Let's create your character!");
        var baseCharacter = JSONBase.LoadPrefab(path, "NoName");
        if (baseCharacter == null)
        {
            Console.WriteLine("Failed to load Character");
        }
        var Player = new Character.CharacterBuilder()
            .WithName(GetCharacterName())
            .WithCharRace(GetCharacterRace())
            .WithStats(baseCharacter.Stats)
            .WithCombatStats(baseCharacter.CombatStats)
            .AsBot(baseCharacter.IsBot)
            .WithStatus(baseCharacter.Statuses)
            .WithExperience(baseCharacter.Experience)
            .WithRarity(baseCharacter.Rarity)
            .Build();
        Player.Stats = GetPlayerStats(AccordingToRace(Player.CharRace));
        Player.CombatStats = CalcCombatStats(Player.Stats);
        Console.Clear();
        Console.WriteLine(Player.ToString());
        if (Functions.InputConfirm("Do you want to save your character?"))
        {
            if (JSONBase.Add(Player))
            {
                Console.WriteLine("Player added to DB");
            }
            else
            {
                Console.WriteLine("Player not added to DB");
            }
        }
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
                Console.Write("Try again.");
                return GetCharacterName();
            }
            else 
            {
                bool YesOrNo = Functions.InputConfirm($"You have chosen: {name}, confirm?");
                if (YesOrNo == false)
                {
                    Console.WriteLine("Choose again.");
                    return GetCharacterName();
                }
                else
                {
                    Console.WriteLine("\nSuccess! Now, lets proceed to Race selection.");
                    Console.Write("Press any key to continue...");
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
        selectedIndex = Menu.GetOption(MenuItems,selectedIndex, "Select your Race:");
        PlayerRaces playerRace = (PlayerRaces)selectedIndex;
        bool confirm = Functions
            .InputConfirm($"You have chosen: {playerRace}, confirm?");
        if (confirm)
        {
            Console.WriteLine($"\nSuccess! You have chosen: {playerRace}.");    
            Console.Write("Press any key to continue...");
            return playerRace.ToString();
        }
        else
        {
            Console.WriteLine("Choose again.");
            return GetCharacterRace();
        }
    }

    private static Stats GetPlayerStats(Stats stats)
    {
        Stats baseStats = new Stats(stats.Strength, stats.Agility, stats.Intellect);

        string [] MenuItems = {
            "Strength",
            "Agility",
            "Intellect"
        };
        int [] MenuValues = {
            baseStats.Strength,
            baseStats.Agility,
            baseStats.Intellect
        };
        int [] chosenStats = Menu.GetOptionWithSelection(MenuItems, MenuValues, "Select your stats", baseStats, 30);
        Stats currentStats = new Stats(chosenStats[0], chosenStats[1], chosenStats[2]);
        CombatStats currCombatStats = CalcCombatStats(currentStats);
        bool confirm = Functions
            .InputConfirm($"You have chosen: {chosenStats[0]} Strength, {chosenStats[1]} Agility, {chosenStats[2]} Intellect\n"+
            $"This will give you:\nHealth: {currCombatStats.Health}\n" +
            $"Mana: {currCombatStats.Mana}\n" +
            $"Min Damage: {currCombatStats.MinDamage}\n" +
            $"Max Damage: {currCombatStats.MaxDamage}\n" +
            $"Armor: {currCombatStats.Armor}\n" +
            $"Evasion: {currCombatStats.Evasion}\nDo you confirm?");
        if (confirm)
        {
            Console.WriteLine($"Success!");
        }
        else
        {
            Console.WriteLine("Choose again.");
            return GetPlayerStats(stats);
        }
        Stats playerStats = new Stats(chosenStats[0], chosenStats[1], chosenStats[2]);
        return playerStats;
    }

    public static CombatStats CalcCombatStats(Stats stats)
    {
        float [] CombatStats = {
            stats.Strength * 10,
            stats.Intellect * 10,
            stats.Strength * 1.2f,
            stats.Strength * 1.3f,
            stats.Agility * stats.Strength / 30,
            stats.Agility /10
        };
        CombatStats playerCombatStats = new CombatStats(
            CombatStats[0],
            CombatStats[1],
            CombatStats[2],
            CombatStats[3],
            CombatStats[4],
            CombatStats[5]
        );
        return playerCombatStats;
    }
    private static Stats AccordingToRace(string race)
    {
        switch(race){
            case "Human":
                return new Stats(6, 8, 6);
            case "Elf":
                return new Stats(4, 8, 8);
            case "Dwarf":
                return new Stats(10, 6, 4);
            case "Orc":
                return new Stats(12, 6, 2);
            case "Gnome":
                return new Stats(9, 6, 5);
            case "HalfElf":
                return new Stats(5, 8, 7);
            case "HalfOrc":
                return new Stats(8, 7, 5);
            case "Tiefling":
                return new Stats(6, 7, 7);
            default:
                Console.WriteLine("Something went wrong");
                return new Stats(0, 0, 0);
        }
    }

}
using DragonCave.DB;
using Newtonsoft.Json;
namespace DragonCave;

public class Game
{
    public static void StartGame()
    {
        Console.Clear();
        Console.CursorVisible = true;

        Console.WriteLine("Welcome to the Dragon cave!");
        Console.WriteLine("Starting new game...");
        
        var Player = PlayerProfileCreation.CreateProfile();

        Console.WriteLine($"So, {Player.Name}, you think {Player.CombatStats.Health}HP is enough to beat the Dragon?");
        var baseDragon = LoadFromDB.LoadCreature("/Users/genaprhd/VSCode/DragonCave/DragonCave/DB/Creatures.json", "Erandol");
        var Dragon = new Character.CharacterBuilder()
            .WithName(baseDragon.Name)
            .WithCharRace(baseDragon.CharRace)
            .WithStats(baseDragon.Stats)
            .WithCombatStats(baseDragon.CombatStats)
            .AsBot(baseDragon.IsBot)
            .WithStatus(baseDragon.Statuses)
            .WithExperience(baseDragon.Experience)
            .WithRarity(baseDragon.Rarity)
            .Build();
        Console.WriteLine(Dragon.ToString());
        Thread.Sleep(1000);
        Console.WriteLine($"The Dragon waits, it has {Dragon.CombatStats.Health}HP. Throw the dice! You have 3 tries.");
        var damageMultiplier = DiceRollGame.Roll();
        Player.CombatStats.MinDamage *= damageMultiplier;
        Player.CombatStats.MaxDamage *= damageMultiplier;
        Fight.GameIsOn(Player, Dragon);
    }
}

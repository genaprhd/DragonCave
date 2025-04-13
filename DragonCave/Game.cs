using Newtonsoft.Json;
namespace DragonCave;

public class Game
{
    public static void StartGame()
    {
        Console.WriteLine("Welcome to the Dragon cave!");
        Console.WriteLine("Starting new game...");
        
        var Player = PlayerProfileCreation.CreateProfile();
        
        Console.WriteLine($"So, {Player.Name}, you think {Player.CombatStats.Health}HP is enough to beat the Dragon?");

        var Dragon = new Character.CharacterBuilder("Erandol", "Dragon");
       
        Thread.Sleep(1000);
        Console.WriteLine($"The Dragon waits, it has {Dragon.CombatStats.Health}HP. Throw the dice! You have 3 tries.");
        Player.CombatStats.MinDamage *= DiceRollGame.Roll();
        Player.CombatStats.MaxDamage *= DiceRollGame.Roll();
        Fight.GameIsOn(Player, Dragon);
    }
}

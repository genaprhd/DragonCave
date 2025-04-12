using DragonCave.DB;

namespace DragonCave;

public class Game
{
    public static void StartGame()
    {
        DatabaseInitializer.InitializeDatabase();
        
        Console.WriteLine("Welcome to the Dragon cave!");
        Character player = new Character(Functions.GetCharacterName(),
            Functions.GetCharacterHealth(),
            5.0f,
            2.0f,
            17,
            false,
            Statuses.Base,
            100,
            100,
            Rarities.Common);
        
        Console.WriteLine($"So, {player.Name}, you think {player.Health}HP is enough to beat the Dragon?");
        
        Character dragon = new Character("Erandol",
            150.0f,
            10.0f,
            5.0f,
            17,
            true,
            Statuses.Base,
            10000,
            1000,
            Rarities.Legendary);
       
        Thread.Sleep(1000);
        Console.WriteLine($"The Dragon waits, it has {dragon.Health}HP. Throw the dice! You have 3 tries.");
        player.Damage *= DiceRollGame.Roll();
        Fight.GameIsOn(player, dragon);
    }
}

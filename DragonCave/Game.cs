namespace DragonCave;

public class Game
{
    public static void StartGame()
    {
        
        Console.WriteLine("Welcome to the Dragon cave!");
        Character player = new Character(Functions.GetCharacterName(),Functions.GetCharacterHealth(), 5.0f, 2.0f, 17, false, statuses.Base);
        
        Console.WriteLine($"So, {player.Name}, you think {player.Health}HP is enough to beat the Dragon?");
        
        Character dragon = new Character("Erandol", 150.0f,10.0f, 5.0f, 17, true, statuses.Base);
       
        Thread.Sleep(1000);
        Console.WriteLine($"The Dragon waits, it has {dragon.Health}HP. Throw the dice! You have 3 tries.");
        player.Damage *= DiceRollGame.Roll();
        Fight.GameIsOn(player, dragon);
    }
}

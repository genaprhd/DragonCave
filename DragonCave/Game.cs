namespace DragonCave;

public class Game
{
    public static void StartGame()
    {
        
        Console.WriteLine("Welcome to the Dragon cave!");
        Character player = new Player(Functions.GetCharacterName(),Functions.GetCharacterHealth(), 0f, 0f);
        
        Console.WriteLine($"So, {player.Name}, you think {player.Health}HP is enough to beat the Dragon?");
        
        Character dragon = new Dragon("Erandol", 150.0f,3.0f, 5.0f, true);
       
        Thread.Sleep(1000);
        Console.WriteLine($"The Dragon waits, it has {dragon.Health}HP. Throw the dice! You have 3 tries.");
        float bonusDamage = DiceRollGame.Roll();
        
        Fight.GameIsOn(player, dragon, bonusDamage);
    }
}

namespace DragonCave;

public class Game
{
    public static void StartGame()
    {
        
        Console.WriteLine("Welcome to the Dragon cave! Name yourself, mortal.");
        Character player = new Player();
        player.Name = Functions.GetCharacterName();
        
        
        Console.WriteLine("How strong you think you are? Insert your HP amount");
        player.Health = Functions.GetCharacterHealth();
        Console.WriteLine($"So, {player.Name}, you think {player.Health}HP is enough to beat the Dragon?");
        
        
        Character dragon = new Dragon();
        dragon.Health = 150.0f;
        dragon.Name = "Erandol";
        
        Thread.Sleep(1000);
        Console.WriteLine($"The Dragon waits, it has {dragon.Health}HP. Throw the dice! You have 3 tries.");
        int bonusDamage = DiceRollGame.Roll();
        
        Fight.GameIsOn(player, dragon);
    }
}

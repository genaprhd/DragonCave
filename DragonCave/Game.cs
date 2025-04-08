namespace DragonCave;

public class Game
{
    public static void StartGame()
    {
        bool play = true;
        Console.WriteLine("Welcome to the Dragon cave! Name yourself, mortal.");
        Characters player = new Player();
        player.Name = Functions.GetCharacterName();
        Console.WriteLine("How strong you think you are?");
        player.Health = Functions.GetCharacterHealth();
        Console.WriteLine($"So, {player.Name}, you think {player.Health}HP is enough to beat the Dragon?");
        Characters dragon = new Dragon();
        dragon.Health = 150.0f;
        dragon.Name = "Erandol";
        Thread.Sleep(1000);
        Console.WriteLine($"The Dragon waits, it has {dragon.Health}HP. Throw the dice! You have 3 tries.");
        int bonusDamage = DiceRollGame.Roll();
        while (dragon.Health >= 0 && player.Health >= 0)
        {
            Fight.GameIsOn(player.Name, dragon.Name);
        }
    }
}

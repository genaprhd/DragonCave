namespace DragonCave;

public class Game
{
    public static void StartGame()
    {
        bool play = true;
        Console.WriteLine("Welcome to the Dragon cave! Name yourself, mortal.");
        Characters Player = new Player();
        Player.Name = Functions.GetCharacterName();
        Console.WriteLine("How strong you think you are?");
        Player.Health = Functions.GetCharacterHealth();
        Console.WriteLine($"So, {Player.Name}, you think {Player.Health}HP is enough to beat the Dragon?");
        Characters Dragon = new Dragon();
        Dragon.Health = 150.0f;
        Dragon.Name = "Erandol";
        Thread.Sleep(1000);
        Console.WriteLine($"The Dragon waits, it has {Dragon.Health}HP. Throw the dice! You have 3 tries.");
        int bonusDamage = DiceRollGame.Roll();
        int turn = 0;
        int option = 0;
        int Move1 = 0;
        int Move2 = 0;
        
        while (Dragon.Health >= 0 && Player.Health >= 0)
        {
            while (true)
            {
                turn++;
                if (turn % 2 != 0)
                {
                    Thread.Sleep(1000);
                    Console.Write(
                        $"{Player.Name}, your turn!"); 
                    Move1 = Fight.MakeATurn(Player.Name, option, false);
                }
                else if(turn % 2 == 0)
                {
                    option = Functions.GetRandomNumber(1, 2+1);
                    Thread.Sleep(1000);
                    Move2 = Fight.MakeATurn(Dragon.Name, option, true);
                }
                Fight.Battle(Move1, Move2);
            }
        }
    }
}
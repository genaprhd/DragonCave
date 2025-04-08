namespace DragonCave;

public class Fight
{
    public static int Battle(Characters player, Characters dragon, int move1, int move2)
    {
        int Winner = 0;
        if (move1 == 1)
        {
            if (move2 == 1)
            {
                
            }
        }
        return 0;
    }

    public static int MakeATurn(string name, int option, bool isBot)
    {
        if (isBot == false)
        {
            Thread.Sleep(2000);
            Console.WriteLine(" Make your move!\n 1. Attack (5-15 damage)\n 2. Block (3-5 damage)\n Your answer: ");
            option = Functions.GetOption();
        }

        switch (option)
            {
                case 1:
                    Thread.Sleep(1000);
                    Console.WriteLine($"{name} choose to Attack!");
                    option = 0;
                    return 1;
                case 2:
                    Thread.Sleep(1000);
                    Console.WriteLine($"{name} choose to Block!");
                    option = 0;
                    return 2;
            }
        return option = 0;
    }

    public static void GameIsOn(string playerName, string mobName)
    {
        int turn = 0;
        int move1 = 0;
        int move2 = 0;
        int option = 0;
        while (true)
        {
            turn++;
            if (turn % 2 != 0)
            {
                Thread.Sleep(1000);
                Console.Write(
                    $"{playerName}, your turn!");
                move1 = Fight.MakeATurn(playerName, option, false);
            }
            else if (turn % 2 == 0)
            {
                option = Functions.GetRandomNumber(1, 2 + 1);
                Thread.Sleep(1000);
                move2 = Fight.MakeATurn(mobName, option, true);
            }
            Battle(playerName, mobName, move1, move2);
        }
    }
}
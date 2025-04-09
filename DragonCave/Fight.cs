using System.Security.Cryptography;

namespace DragonCave;

public class Fight
{
    private static int Battle(Characters player, Characters dragon, int move1, int move2)
    {
        while (dragon.Health >= 0 && player.Health >= 0)
        {
            int Winner = 0;
            if (move1 == 1)
            {
                if (move2 == 1)
                {
                    //TODO Здесь надо прописать логику боя, нанесения урона, учитываыя статусы, резисты игрока, персонажей
                }
            }
            return 0;
        }
        return 0;
    }

    private static int MakeATurn(string name, int option, bool isBot)
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

    public static void GameIsOn(Characters player, Characters dragon)
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
                    $"{player.Name}, your turn!");
                move1 = Fight.MakeATurn(player.Name, option, false);
            }
            else if (turn % 2 == 0)
            {
                option = Functions.GetRandomNumber(1, 2 + 1);
                Thread.Sleep(1000);
                move2 = Fight.MakeATurn(dragon.Name, option, true);
            }
            Battle(player, dragon, move1, move2);
        }
    }
}
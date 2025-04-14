namespace DragonCave;

public class DiceRollGame
{
    //TODO класс должен возвращать только значение касающееся победы, поражения или Разгрома. Сооответсвенно надо переписать возвращаемые значения
    public static float Roll()
    {
        float damage = 1;
        int neededNum = Functions.GetRandomNumber(1, 20+1);
        Console.WriteLine($"Your needed number is {neededNum}");
        int diceRoll = 1;
        while (diceRoll <= 3 && (damage != 0.5f && damage != 2))
        {
            Thread.Sleep(1000);
            int gotNum = Functions.GetRandomNumber(1, 20+1);
            Console.WriteLine($"Your gotten number is {gotNum}. Current roll number is {diceRoll}");
            damage = DidIWin(gotNum, neededNum);
            diceRoll++;
        }
        return damage;
    }

    private static float DidIWin(int playerScore, int dragonScore)
    {
        //bool isWinner = false;
        //bool defeat = false;
        int summ = dragonScore -  playerScore;
        if (playerScore < dragonScore && summ < 10)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Oh! Your dice ({playerScore}) is less then Needed({dragonScore})!\n You have lost the dice game. No damage changes!");
            return 1;
        }
        else if (playerScore < dragonScore && summ >= 10)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Eto Razjeb, your dice ({playerScore}) is smaller then Needed ({dragonScore}) by {summ}!\n You have been crushed in the dice game. Damage decreased x2!");
            return 0.5f;
        }
        else if (playerScore > dragonScore)
        {
            Thread.Sleep(2000);
            Console.WriteLine(
                $"Zaebis! Your dice ({playerScore}) is greater then Needed ({dragonScore}) by {(-1 * summ)}!\n You have won the dice game. Your damage increases x2!");
            return 2;
        }
        return 1;
    }
    
}
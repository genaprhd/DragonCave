namespace DragonCave;

public class Fight
{
    private static void Battle(Character person1, Character person2, int move1, int move2, float bonusDamage)
    {
        if (move1 == 1)
        {
            Attack(person1, person2, bonusDamage);
            if (move2 == 1)
            {
                Attack(person2, person1, 4f);
            }
            else
            {
                Block(person2, person1, 4f);
            }
        }
        else if (move1 == 2)
        {
            Block(person1, person2, bonusDamage);
            if (move2 == 1)
            {
                Attack(person2, person1, 4f);
            }
            else
            {
                Block(person2, person1, 4f);
            }
        }
        Console.WriteLine($"{person1.Health}HP - new health. {person2.Health} HP\n");
    }

    private static int MakeATurn(string name, int option, bool isBot)
    {
        if (!isBot)
        {
            Thread.Sleep(2000);
            Console.WriteLine(" Make your move!\n1. Attack (5-15 damage)\n2. Block (3-5 damage)\nYour answer: ");
            option = Functions.GetOption();
        }

        switch (option)
            {
                case 1:
                    Thread.Sleep(1000);
                    actions chosen1= actions.Attack;
                    Console.WriteLine($"{name} choose to {chosen1}!\n");
                    return 1;
                case 2:
                    Thread.Sleep(1000);
                    actions chosen2 = actions.Block;
                    Console.WriteLine($"{name} choose to {chosen2}!\n");
                    return 2;
            }
        return option = 0;
    }

    public static void GameIsOn(Character person1, Character person2, float bonusDamage)
    {
        int turn = 0;
        int move1 = 0;
        int move2 = 0;
        int option = 0;
        while (person1.Health >= 0 && person2.Health >= 0)
        {
            turn++;
            if (turn % 2 != 0)
            {
                Thread.Sleep(1000);
                Console.Write(
                    $"{person1.Name}, your turn!");
                move1 = MakeATurn(person1.Name, option, false);
            }
            else if (turn % 2 == 0)
            {
                move2 = MakeATurn(person2.Name, Functions.GetRandomNumber(1, 3), true);
            }
            Battle(person1, person2, move1, move2, bonusDamage);
        }
    }

    protected static void Attack(Character person1, Character person2, float bonusDamage)
    {
        int chanceToMiss = person2.Evasion;
        int hit = Functions.GetRandomNumber(1, 100 + 1);
        Console.WriteLine($"{person1.Name} chance to hit {hit}, Chance to miss is {chanceToMiss}!\n");
        if (hit >= chanceToMiss)
        {
            person1.Damage = Functions.GetRandomNumber(5, 10);
            float damage = person1.Damage * bonusDamage - person2.Armor;
            if (damage < 0)
            {
                Console.WriteLine($"Не пробил!");
                damage = 0;
            }

            person2.Health = person2.Health - damage;
            Console.WriteLine($"{person2.Name} has been hit and recieved {damage}!\n");
        }
        else
        {
            Console.WriteLine($"{person1.Name} missed!\n");
        }
    }
    
    //TODO вынести в отдельный метод расчет вероятности попадания ударом, избавиться от "магических" чисел. На этой основе посчитать логику

    protected static void Block(Character person1, Character person2, float bonusDamage)
    {
        int chanceToMiss = person2.Evasion;
        int hit = Functions.GetRandomNumber(1, 100 + 1);
        Console.WriteLine($"{person1.Name} chance to hit {hit}, Chance to miss is {chanceToMiss}!\n");
        if (hit >= chanceToMiss)
        {
            person2.Damage = Functions.GetRandomNumber(5, 10);
            float damage = person2.Damage * bonusDamage - person1.Armor * 4;
            if (damage < 0)
            {
                Console.WriteLine($"Не пробил!");
                damage = 0;
            }
            person1.Health = person1.Health - damage;
            Console.WriteLine($"{person1.Name} has been hit and recieved {damage}!\n");
        }
        else
        {
            Console.WriteLine($"{person1.Name} missed!\n");
        }
    }

}
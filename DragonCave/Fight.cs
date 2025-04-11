namespace DragonCave;

public class Fight
{
    private static void Battle(Character person, Character mob, int move1, int move2, float bonusDamage)
    {
        if (move1 == 1)
        {
            if (move2 == 1)
            {
                Attack(person, mob, bonusDamage);
            }
            else
            {
                Block(mob, person, 4f);
            }
        }
        else if (move1 == 2)
        {
            if (move2 == 1)
            {
                Attack(mob, person, 4f);
            }
            else
            {
                Block(mob, person, bonusDamage);
            }
        }

        Console.WriteLine($"{person.Health}HP - new health. {mob.Health} HP\n");
    }

    private static int MakeATurn(string name, int option, bool isBot)
    {
        if (!isBot)
        {
            Thread.Sleep(2000);
            Console.WriteLine(" Make your move!\n1. Attack (5-15 damage)\n2. Block (3-5 damage)\nYour answer: "); //TODO добавить подстановку значений возможного урона
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

    public static void GameIsOn(Character person, Character mob, float bonusDamage)
    {
        int turn = 0;
        int move1 = 0;
        int move2 = 0;
        int option = 0;
        while (person.Health >= 0 && mob.Health >= 0)
        {
            move1 = move2 = 0;
            turn++;
            Console.WriteLine($"Turn №{turn}!");
            if (turn % 2 != 0)
            {
                Thread.Sleep(1000);
                Console.Write(
                    $"{person.Name}, your turn!");
                move1 = MakeATurn(person.Name, option, false);
                move2 = MakeATurn(mob.Name, Functions.GetRandomNumber(1,3), true);
            }
            else if (turn % 2 == 0)
            {
                move1 = MakeATurn(mob.Name, Functions.GetRandomNumber(1, 3), true);
                move2 = MakeATurn(person.Name, option, false);
            }
            Battle(person, mob, move1, move2, bonusDamage);
        }
        
    }

    private static bool hit(Character person)
    {
        int MIN_CHANCE = 1;
        int MAX_CHANCE = 101;
        int chanceToMiss = person.Evasion;
        int chanceToHit = Functions.GetRandomNumber(MIN_CHANCE, MAX_CHANCE);

        if (chanceToHit >= chanceToMiss)
        {
            return true;
        }
        return false;
    } 
    
    protected static void Attack(Character person1, Character person2, float bonusDamage)
    {
        if (hit(person1))
        {
            person1.Damage = Functions.GetRandomNumber(5, 15); //TODO позднее добавить поле для зачитывания минимального, максимального урона
            float damage = person1.Damage * bonusDamage - person2.Armor;
            if (damage < 0)
            {
                Console.WriteLine($"Не пробил!");
                damage = 0;
            }
            float oldHealth = person2.Health;
            person2.Health -= damage;
            Console.WriteLine($"{person2.Name} has been hit and recieved {damage} damage!\n ({oldHealth}) ---> ({person2.Health})");
        }
        else
        {
            Console.WriteLine($"{person1.Name} missed!\n");
        }
    }
    
    //TODO избавиться от "магических" чисел

    protected static void Block(Character person1, Character person2, float bonusDamage)
    {
        if (hit(person1))
        {
            Console.WriteLine($"{person1.Name} choose to block! Armor increased x4!");
            float damage = Functions.GetRandomNumber(5, 10) * bonusDamage - person1.Armor * 4;
            if (damage < 0)
            {
                Console.WriteLine($"Не пробил!");
                damage = 0;
            }
            float oldHealth = person2.Health;
            person1.Health -= damage;
            Console.WriteLine($"{person2.Name} has been hit and received {damage} damage!\n ({oldHealth}) ---> ({person2.Health})");
        }
        else
        {
            Console.WriteLine($"{person1.Name} missed!\n");
        }
    }

}
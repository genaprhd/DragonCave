namespace DragonCave;

public class Fight
{
    private static void Battle(Character person, Character mob, int move1, int move2)
    {
        if (move1 == 1)
        {
            if (move2 == 1)
            {
                Attack(person, mob);
            }
            else
            {
                mob.Status = statuses.Blocked;
                Attack(person, mob);
            }
        }
        else if (move1 == 2)
        {
            if (move2 == 1)
            {
                Attack(mob, person);
            }
            else
            {
                Attack(mob, person);
            }
        }
    }

    private static int MakeATurn(Character person, int option)
    {
        if (!person.IsBot)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Make your move!\n1. Attack ({person.Damage})\n2. Block (3-5 damage)\nYour answer: "); //TODO добавить подстановку значений возможного урона
            option = Functions.GetOption();
        }

        switch (option)
            {
                case 1:
                    Thread.Sleep(1000);
                    actions chosen1= actions.Attack;
                    Console.WriteLine($"{person.Name} choose to {chosen1}!\n");
                    return 1;
                case 2:
                    Thread.Sleep(1000);
                    actions chosen2 = actions.Block;
                    Console.WriteLine($"{person.Name} choose to {chosen2}!\n");
                    return 2;
            }
        return option = 0;
    }

    public static void GameIsOn(Character person, Character mob)
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
                move1 = MakeATurn(person, option);
                move2 = MakeATurn(mob, Functions.GetRandomNumber(1,3));
            }
            else if (turn % 2 == 0)
            {
                move1 = MakeATurn(mob, Functions.GetRandomNumber(1, 3));
                move2 = MakeATurn(person, option);
            }
            Battle(person, mob, move1, move2);
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
    
    protected static void Attack(Character person1, Character person2)
    {
        if (hit(person1) && person2.Status != statuses.Blocked)
        {
            person1.Damage = Functions.GetRandomNumber(5, 15); //TODO позднее добавить поле для зачитывания минимального, максимального урона
            float damage = person1.Damage - person2.Armor;
            if (damage < 0)
            {
                Console.WriteLine($"Не пробил!");
                damage = 0;
            }
            float oldHealth = person2.Health;
            person2.Health -= damage;
            Console.WriteLine($"{person2.Name} has been hit and received {damage} damage!\n ({oldHealth})HP ---> ({person2.Health})HP");
        }
        else if (hit(person1) && person2.Status == statuses.Blocked)
        {
            person1.Damage = Functions.GetRandomNumber(5, 15); //TODO позднее добавить поле для зачитывания минимального, максимального урона
            float damage = person1.Damage - person2.Armor;
            if (damage < 0)
            {
                Console.WriteLine($"Не пробил!");
                damage = 0;
            }
            float oldHealth = person2.Health;
            person2.Health -= damage;
            Console.WriteLine($"{person2.Name} has been hit and received {damage} damage!\n ({oldHealth})HP ---> ({person2.Health})HP");
            Console.WriteLine($"{person1.Name} missed!\n");
        }
    }
}
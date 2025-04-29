namespace DragonCave;

public class Fight
{
    public static void GameIsOn(Character person, Character mob)
    {
        int turn = 0;
        int option = 0;
        while (person.CombatStats.Health >= 0 && mob.CombatStats.Health >= 0)
        {
            int move1, move2 = 0;
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
            else
            {
                move1 = MakeATurn(mob, Functions.GetRandomNumber(1, 3));
                move2 = MakeATurn(person, option);
            }
            Battle(person, mob, move1, move2);
        }
    }
    internal static void Battle(Character person, Character mob, int move1, int move2)
    {
        if (move1 == 1)
        {
            if (move2 == 1)
            {
                Attack(person, mob);
                Attack(mob, person);
            }
            else
            {
                mob.Statuses = Statuses.Blocked;
                Attack(person, mob);
            }
        }
        else if (move1 == 2)
        {
            if (move2 == 1)
            {
                Attack(mob, person);
                Attack(person, mob);
            }
            else
            {
                person.Statuses = Statuses.Blocked;
                Attack(mob, person);
            }
        }
    }
    internal static int MakeATurn(Character person, int option)
    {
        if (!person.IsBot)
        {
            Thread.Sleep(2000);
            Console.WriteLine(
                $" Make your move!\n1. Attack ({person.CombatStats.MaxDamage}HP)\n2. Block (-{4 * person.CombatStats.Armor} damage)\nYour answer: ");
            option = Functions.GetOption();
        }

        switch (option)
            {
                case 1:
                    Thread.Sleep(1000);
                    Actions chosen1= Actions.Attack;
                    Console.WriteLine($"{person.Name} choose to {chosen1}!\n");
                    return 1;
                case 2:
                    Thread.Sleep(1000);
                    Actions chosen2 = Actions.Block;
                    Console.WriteLine($"{person.Name} choose to {chosen2}!\n");
                    return 2;
            }
        return option = 0;
    }
    internal static bool hit(Character person)
    {
        int MIN_CHANCE = 1;
        int MAX_CHANCE = 101;
        float chanceToMiss = person.CombatStats.Evasion;
        int chanceToHit = Functions.GetRandomNumber(MIN_CHANCE, MAX_CHANCE);

        if (chanceToHit >= chanceToMiss)
        {
            return true;
        }
        return false;
    } 
    internal static void Attack(Character person1, Character person2)
    {
        if (hit(person1) && person2.Statuses != Statuses.Blocked)
        {
            DealDamage(person1, person2);
        }
        else if (hit(person1) && person2.Statuses == Statuses.Blocked)
        {
            DealDamage(person1, person2);
        }
        else if (!hit(person1))
        {
            Console.WriteLine($"{person1.Name} missed!\n");
        }
    }
    private static void DealDamage(Character person1, Character person2)
    {
        person1.CombatStats.Evasion = Functions.Damage(5,15); //TODO позднее добавить поле для зачитывания минимального, максимального урона
        float damage = 0;
        if (person2.Statuses == Statuses.Blocked)
        {
            damage = person1.CombatStats.MaxDamage - 4 * person2.CombatStats.Evasion;//Сменить на damage
        }
        else
        {
            damage = person1.CombatStats.MaxDamage - person2.CombatStats.Evasion;
        }
        if (damage <= 0)
        {
            Console.WriteLine($"{person1.Name} не пробил!");
            damage = 0;
        }
        float oldHealth = person2.CombatStats.Health;
        person2.CombatStats.Health -= damage;
        Console.WriteLine($"{person2.Name} has been hit and received {damage} damage!\n ({oldHealth})HP ---> ({person2.CombatStats.Health})HP");
    }
}
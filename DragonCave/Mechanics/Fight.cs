namespace DragonCave;

public class Fight
{
    public static void GameIsOn(Character person, Character mob)
    {
        int turn = 0;
        while (person.CombatStats.Health > 0 && mob.CombatStats.Health > 0)
        {
            int move1, move2;
            turn++;
            Console.WriteLine($"Turn №{turn}!");
            if (turn % 2 != 0)
            {
                move1 = MakeATurn(person);
                move2 = MakeATurn(mob);
            }
            else
            {
                move1 = MakeATurn(mob);
                move2 = MakeATurn(person);
            }
            Battle(person, mob, move1, move2);
        }
    }
    internal static void Battle(Character person, Character mob, int move1, int move2)
    {
        if (move1 == 0)
        {
            if (move2 == 0)
            {
                Attack(person, mob);
                Attack(mob, person);
            }
            else
            {
                Console.WriteLine($"{mob.Name}'s armor increased by 4: ({4 * mob.CombatStats.Armor})!");
                float regularArmor = mob.CombatStats.Armor;
                mob.CombatStats.Armor *= 4;
                Attack(person, mob);
                //Attack(mob, person);
                mob.CombatStats.Armor = regularArmor;
                Thread.Sleep(3000);
            }
        }
        else if (move1 == 1)
        {
            if (move2 == 0)
            {
                Console.WriteLine($"{person.Name}'s armor increased by 4: ({4 * person.CombatStats.Armor})!");
                float regularArmor = person.CombatStats.Armor;
                mob.CombatStats.Armor *= 4;
                Attack(mob, person);
                //Attack(person, mob);
                person.CombatStats.Armor = regularArmor;
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine($"{person.Name} has been blocked and skipped his Attack!\n");
                Console.WriteLine($"{mob.Name} has been blocked and skipped his Attack!\n");
                Thread.Sleep(5000);
            }
        }
    }
    internal static int MakeATurn(Character person)
    {
        int option;
        if (!person.IsBot)
        {
            string [] MenuItems = {
                $"\nAttack ({person.CombatStats.MaxDamage}HP)",
                $"Block (-{4 * person.CombatStats.Armor} damage)"
            };
            option = Menu.GetOption(MenuItems, 0, "Choose your action: ");
        }
        else{
            option = Functions.GetRandomNumber(0, 2);
        }
        Console.WriteLine("=====================\n");
        switch (option)
            {
                case 0:
                    Thread.Sleep(2000);
                    Actions chosen1= Actions.Attack;
                    Console.WriteLine($"{person.Name} choose to {chosen1}!\n");
                    Console.WriteLine("=====================\n");

                    return option;
                case 1:
                    Thread.Sleep(2000);
                    Actions chosen2 = Actions.Block;
                    Console.WriteLine($"{person.Name} choose to {chosen2}!\n");
                    Console.WriteLine("=====================\n");
                    return option;
            }
        return option;
    }
    internal static bool hit(Character person)
    {
        int MIN_CHANCE = 1;
        int MAX_CHANCE = 101;
        int chanceToMiss = person.CombatStats.Evasion;
        int chanceToHit = Functions.GetRandomNumber(MIN_CHANCE, MAX_CHANCE);

        if (chanceToHit >= chanceToMiss)
        {
            return true;
        }
        return false;
    } 
    internal static void Attack(Character person1, Character person2)
    {
        if (hit(person2))
        {
            DealDamage(person1, person2);
        }
        else
        {
            Console.WriteLine($"{person1.Name} missed!\n");
            Thread.Sleep(1000);
        }
    }
    private static void DealDamage(Character person1, Character person2)
    {
        float damage;
        damage = Functions.RandomFloatInRange(person1.CombatStats.MinDamage, person1.CombatStats.MaxDamage) - person2.CombatStats.Armor;
        if (damage <= 0)
        {
            Console.WriteLine($"{person1.Name} не пробил!");
            Thread.Sleep(1000);
            damage = 0;
        }
        float oldHealth = person2.CombatStats.Health;
        person2.CombatStats.Health -= damage;
        Console.WriteLine($"{person2.Name} has been hit and received {damage} damage!\n ({oldHealth})HP ---> ({person2.CombatStats.Health})HP");
        Thread.Sleep(1000);
    }
}
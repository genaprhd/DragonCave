using System.ComponentModel.Design;

namespace DragonCave;

public class Functions
{
    public static float GetCharacterHealth()
    {
        float health = 0.0f;
        while (true)
        {
            if (float.TryParse(Console.ReadLine(), out health) && health > 0)
                return health;
            else
                Console.WriteLine("Incorrect input! Try again!");
        }
    }

    public static int GetOption()
    {
        int option = 0;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out option) && option > 0)
                return option;
            else
            {
                Console.WriteLine("Incorrect input! Try again!");
            }
        }
    }
    public static string GetCharacterName()
    {
        int tryNum = 0;
        string name = "";

        while (true) 
        {
            tryNum++; 
            
            if (tryNum > 1)
            {
                Console.WriteLine("Give me correct Name!");
            }

            name = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
            {
                return name;
            }
        }
    }
    
    private static readonly Random Getrandom = new Random();

    public static int GetRandomNumber(int min,
        int max)
    {
        lock (Getrandom)
        {
            return Getrandom.Next(min,
                max);
        }
    }
    
    public static int MakeATurn(string Name, int option, bool isBot)
    {
        if (isBot == false)
        {
            Thread.Sleep(2000);
            Console.WriteLine(" Make your move!\n 1. Attack (5-15 damage)\n 2. Block (3-5 damage)\n Your answer: ");
            option = GetOption();
        }
        {
            switch (option)
            {
                case 1:
                    Thread.Sleep(1000);
                    Console.WriteLine($"{Name} choose to Attack!");
                    option = 0;
                    return 1;
                case 2:
                    Thread.Sleep(1000);
                    Console.WriteLine($"{Name} choose to Block!");
                    option = 0;
                    return 2;
            }
        }
       return option = 0;
    }
    public static float HealthChange(float Health, int damage)
    {
        return 0;
    } 
}
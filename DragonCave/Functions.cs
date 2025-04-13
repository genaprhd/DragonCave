namespace DragonCave;

public class Functions
{
    public static float GetCharacterHealth()
    {
        Console.WriteLine("How strong you think you are? Insert your HP amount");
        float health;
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

    private static readonly Random Getrandom = new Random();
    public static int GetRandomNumber(int min, int max)
    {
        lock (Getrandom)
        {
            return Getrandom.Next(min, max);
        }
    }
    public static int Damage(int min, int max)
    {
        lock (Getrandom)
        {
            return Getrandom.Next(min, max);
        }
    }
}
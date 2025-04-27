using System.ComponentModel.DataAnnotations;
using System.Reflection;

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

    public static string[] GetEnumValues<T>() where T : Enum
    {
        var enumType = typeof(T);
        return Enum
            .GetNames(enumType)
            .Select(name =>
            {
                var field = enumType.GetField(name);
                if (field == null) return name;

                var Display = field
                .GetCustomAttribute<DisplayAttribute>(false);
                return Display?.Name ?? name;
            })
            .ToArray();
    }

    public static bool InputConfirm(string message)
    {   
        while (true)
        {
            Console.WriteLine(message);
            if (ConsoleKey.Enter == Console.ReadKey(true).Key)
            {
                return true;
            }
            else if (ConsoleKey.Escape == Console.ReadKey(true).Key)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input! Please press 'Enter' or 'Escape'.");
            }
        }
    }
}
 

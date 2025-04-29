namespace DragonCave;
public class Menu
{
    public static int GetOption(string[] menuItems, int selectedIndex, string message)
    {
        Console.CursorVisible = false;
        while (true)
        {
            DrawMenu(menuItems, selectedIndex, message);
            var key = Console.ReadKey(intercept: true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex == 0)
                        ? menuItems.Length - 1
                        : selectedIndex - 1;
                    break;

                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex == menuItems.Length - 1)
                        ? 0
                        : selectedIndex + 1;
                    break;
                case ConsoleKey.Enter:
                    return selectedIndex;
            }
        }
    }
    public static int [] GetOptionWithSelection(string[] menuItems, int [] menuValues, string message, Stats stats, int limit)
    {
        int [] startValues = menuValues.ToArray();
        Console.CursorVisible = false;
        int selectedIndex = 0;
        while (true)
        {
            int toDistibute = limit - menuValues.Sum();
            DrawMenuWithSelection(menuItems, menuValues, selectedIndex, message, stats, toDistibute);
            var key = Console.ReadKey(intercept: true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex == 0)
                        ? menuItems.Length - 1
                        : selectedIndex - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex == menuItems.Length - 1)
                        ? 0
                        : selectedIndex + 1;
                    break;
                case ConsoleKey.RightArrow:
                if (toDistibute != 0)
                {
                    menuValues[selectedIndex]++;
                    break;
                }
                else
                {
                    Console.WriteLine("You have no points to distribute.");
                    break;
                }
                case ConsoleKey.LeftArrow:
                    menuValues[selectedIndex]--;
                    if (menuValues[selectedIndex] < startValues[selectedIndex])
                        menuValues[selectedIndex] = startValues[selectedIndex];
                    break;
                case ConsoleKey.Enter:
                    if (toDistibute == 0)
                    {
                        return menuValues;
                    }
                    else
                    {
                        Console.WriteLine("You have not distributed all points.");
                        break;
                    }
            }
        }
    }
    static void DrawMenu(string[] menuItems, int selectedIndex, string message = "")
    {
        Console.Clear();
        Console.WriteLine(message);
        for (int i = 0; i < menuItems.Length; i++)
        {
            if (i == selectedIndex)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.ResetColor();
            }
            Console.WriteLine(menuItems[i]);
        }
        Console.ResetColor();
        Console.WriteLine("\nUse Up/Down arrows to select, Enter to confirm.");

    }
    static void DrawMenuWithSelection(string[] menuItems, int [] menuValues, int selectedIndex, string message, Stats stats, int limit)
    {
        Console.Clear();
        Console.WriteLine($"{message} You have {limit} points to distribute.");
        for (int i = 0; i < menuItems.Length; i++)
        {
            if (i == selectedIndex)
            {
               WhiteColored(ConsoleColor.Black, ConsoleColor.Gray);
            }
            else
            {
                Console.ResetColor();
            }
            Console.Write($"{menuItems[i]}");
            Console.ResetColor();
            Console.WriteLine($": {menuValues[i]}");
        }
        Console.ResetColor();
        Console.WriteLine("\nUse Up/Down arrows to select, Left/Right arrows to change values, Enter to confirm.");
    }
    static void WhiteColored(ConsoleColor fg, ConsoleColor bg = ConsoleColor.Black)
    {

        Console.BackgroundColor = bg;
        Console.ForegroundColor = fg;
    }
}

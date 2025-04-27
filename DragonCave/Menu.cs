using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace DragonCave;
public class Menu
{
    public static int GetOption(string[] menuItems, int selectedIndex)
    {
        Console.CursorVisible = false;
        while (true)
        {
            DrawMenu(menuItems, selectedIndex);
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
    static void DrawMenu(string[] menuItems, int selectedIndex)
    {
        Console.Clear();
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

    }
}
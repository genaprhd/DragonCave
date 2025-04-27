namespace DragonCave;

public class StartMenu
{
    static readonly string[] MenuItems = {
        "Новая игра",
        "Загрузить",
        "Кредиты",
        "Выход"
    };
    static int selectedIndex = 0;
    public static void StartScreen()
    {
        Console.WriteLine("Добро пожаловать в DragonCave!\n");
        Console.CursorVisible = false;
        while (true)
        {
            selectedIndex = Menu.GetOption(MenuItems, selectedIndex);
                switch(selectedIndex){
                     case 0:
                        Game.StartGame();
                        break;
                    case 1:
                    // Место для логики загрузки игры
                        Console.Clear();
                        Console.WriteLine("Загрузка игры...");
                        Thread.Sleep(1000);
                        Game.StartGame();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Кредиты:");
                        Console.WriteLine("Разработчик: Геннадий П.");
                        Console.WriteLine("Дизайнер: Геннадий П.");
                        Console.WriteLine("Тестировщик: Геннадий П.");
                        Console.WriteLine("Специальная благодарность: Геннадию П.");
                        Console.WriteLine("Версия: 1.0");
                        Console.WriteLine($"Дата выхода: {DateTime.Now.ToShortDateString()}");
                        Console.WriteLine("Лицензия: MIT");
                        Console.WriteLine("Год: 2025");
                        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню...");
                        Console.ReadKey(intercept: true);
                        StartScreen();
                        break;
                    }
                    if (selectedIndex == MenuItems.Length - 1)
                        ExitGame();
                    break;
            }
        }
    public static void ExitGame()
    {
        Console.Clear();
        Console.WriteLine("Выход из игры...");
        Thread.Sleep(1000);
        Environment.Exit(0);
    }
}

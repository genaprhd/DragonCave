using DragonCave.DB;

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
    public static void Introduction()
    {
        Console.Clear();
        UILib.TypeWriterEffect("Добро пожаловать в Dragon Cave!").Wait();
        UILib.TypeWriterEffect("Это текстовая игра, в которой вы будете исследовать подземелья, сражаться c монстрами и находить сокровища.").Wait();
        UILib.TypeWriterEffect("Нажмите любую клавишу, чтобы продолжить...").Wait();
        Console.ReadKey(intercept: true);
        StartScreen();
    }
    static void StartScreen()
    {   
        Console.Clear();
        Console.CursorVisible = false;
        while (true)
        {
            selectedIndex = Menu.GetOption(MenuItems, selectedIndex, "Dragon Cave");
                switch(selectedIndex){
                     case 0:
                        Game.StartGame();
                        break;
                    case 1:
                    // Место для логики загрузки игры
                        Console.Clear();
                        Console.WriteLine("Загрузка игры...");
                        Thread.Sleep(2000);
                        Console.Clear();
                        if (JSONBase.IfAnyPlayerSaved()){
                            int selectedIndex = Menu.GetOption(JSONBase.GetAllNames(), 0, "Выберите игрока:");

                            if (Functions.InputConfirm($"Вы выбрали {JSONBase.GetAllNames()[selectedIndex]}. Подтвердите выбор?"))
                                {
                                    var Player = JSONBase.LoadPlayer(selectedIndex);
                                    Console.WriteLine(Player.ToString());
                                    Console.WriteLine("Загрузка завершена.");
                                    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                                    Console.ReadKey(intercept: true);
                                    ExitGame();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Выбор отменен.");
                                    Thread.Sleep(1000);
                                    StartScreen();
                                };
                        }
                        else
                        {   
                            Console.WriteLine("Нет сохраненных игроков.");
                            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню...");
                            Console.ReadKey(intercept: true);
                            StartScreen();
                        }
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

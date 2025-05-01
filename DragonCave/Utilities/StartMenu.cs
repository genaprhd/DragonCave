using System.Threading.Tasks;
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
    public static async Task Introduction()
    {
        Console.Clear();
        await UILib.TypeWriterEffect("Добро пожаловать в Dragon Cave!");
        await UILib.TypeWriterEffect("Это текстовая игра, в которой вы будете исследовать подземелья, сражаться c монстрами и находить сокровища.");
        await UILib.TypeWriterEffect("Нажмите любую клавишу, чтобы продолжить...");
        Console.CursorVisible = false;
        UILib.ClearInputBuffer();
        Console.ReadKey(intercept: true);
        MainMenu();
    }
    static void MainMenu()
    {
        Console.Clear();
        Console.CursorVisible = false;
        while (true)
        {
            selectedIndex = Menu.GetOption(MenuItems, selectedIndex, "Главное меню\n");
            switch (selectedIndex)
            {
                case 0:
                    Character Player = PlayerProfileCreation.CreateProfile();
                    Game.StartGame(Player);
                    break;
                case 1:
                    Console.Clear();
                    UILib.TypeWriterEffect("Загрузка игры...");
                    Console.Clear();
                    if (JSONBase.IfAnyPlayerSaved())
                    {
                        int selectedIndex = Menu.GetOption(JSONBase.GetAllNames(), 0, "Выберите игрока:");
                        if (Functions.InputConfirm($"Вы выбрали {JSONBase.GetAllNames()[selectedIndex]}. Подтвердите выбор?"))
                        {
                            Player = JSONBase.LoadPlayer(selectedIndex);
                            UILib.TypeWriterEffect(Player.ToString());
                            UILib.TypeWriterEffect("Загрузка завершена.");
                            UILib.TypeWriterEffect("Нажмите любую клавишу, чтобы продолжить...");
                            Console.ReadKey(intercept: true);
                            Game.StartGame(Player);
                            break;
                        }
                        else
                        {
                            UILib.TypeWriterEffect("Выбор отменен.");
                            Thread.Sleep(1000);
                            MainMenu();
                        }
                        ;
                    }
                    else
                    {
                        UILib.TypeWriterEffect("Нет сохраненных игроков.");
                        UILib.TypeWriterEffect("Нажмите любую клавишу, чтобы вернуться в меню...");
                        Console.ReadKey(intercept: true);
                        MainMenu();
                    }
                    break;
                case 2:
                    Console.Clear();
                    UILib.TypeWriterEffect("Кредиты:");
                    UILib.TypeWriterEffect("Разработчик: Геннадий П.");
                    UILib.TypeWriterEffect("Дизайнер: Геннадий П.");
                    UILib.TypeWriterEffect("Тестировщик: Геннадий П.");
                    UILib.TypeWriterEffect("Специальная благодарность: Геннадию П.");
                    UILib.TypeWriterEffect("Версия: 1.0");
                    UILib.TypeWriterEffect($"Дата выхода: {DateTime.Now.ToShortDateString()}");
                    UILib.TypeWriterEffect("Лицензия: MIT");
                    UILib.TypeWriterEffect("Год: 2025");
                    UILib.TypeWriterEffect("Нажмите любую клавишу, чтобы вернуться в меню...");
                    Console.CursorVisible = false;
                    Console.ReadKey(intercept: true);
                    MainMenu();
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
        UILib.TypeWriterEffect("Выход из игры...");
        Thread.Sleep(1000);
        Environment.Exit(0);
    }
}

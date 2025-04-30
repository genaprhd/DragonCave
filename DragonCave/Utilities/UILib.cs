namespace DragonCave;

public class UILib
{
    private static bool _toSkip = false;
    private static readonly double _baseDelayMean = 40; // Средняя задержка между символами (мс)
    private static readonly double _baseDelayStdDev = 30; // Стандартное отклонение для задержки
    private static readonly double _wordPauseMin = 50; // Мин. пауза после пробела (мс)
    private static readonly double _wordPauseMax = 70; // Макс. пауза после пробела
    private static readonly double _punctuationPauseMin = 20; // Мин. пауза после знаков препинания
    private static readonly double _punctuationPauseMax = 30; // Макс. пауза после знаков
    private static readonly double _thinkingPauseProbability = 0.00; // Вероятность "размышления"
    private static readonly double _errorProbability = 0.02; // Вероятность ошибки

    public static void ClearInputBuffer()
    {
        while (Console.KeyAvailable)
        {
            Console.ReadKey(intercept: true);
        }
    }
        static void EnterKeyListener()
            {
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        if (Console.ReadKey(intercept: true).Key == ConsoleKey.Enter)
                        {
                            _toSkip = true;
                            break;
                        }
                    }
                }
            }
        static void EnterKeyStatus()
        {
            Task enterKeyListenerTask = Task.Run(() => EnterKeyListener());
        }
            
        public static async Task TypeWriterEffectAsync(string text, int typeDelayMs = 100, int eraseDelayMs = 50)
        {
            EnterKeyStatus();
            Console.CursorVisible = true;
            foreach (char c in text)
            {
                Console.Write(c);
                await Task.Delay(typeDelayMs);
            }
            Console.WriteLine();
            for (int i = text.Length; i > 0; i--)
            {
                Console.Write("\b \b");
                await Task.Delay(eraseDelayMs);
            }
        }
    public static void TypeWriterEffect(string text)
    {   
        TypingSimulation(text).Wait();
    }
    private static async Task TypingSimulation(string text)
    {
        EnterKeyStatus();
        _toSkip = false;
        char? prevChar = null;
        Console.CursorVisible = true;
        int i = 0;
        while (i < text.Length)
        {
            foreach (char c in text)
                {
                    if (!_toSkip)
                    {
                        double typeDelayMs = GaussianRandom(_baseDelayMean, _baseDelayStdDev);
                        if (prevChar == c)
                            typeDelayMs *= 0.5;
                        if (char.IsWhiteSpace(c))
                            typeDelayMs = Functions.Getrandom.NextDouble() * (_wordPauseMax - _wordPauseMin) + _wordPauseMin;
                        if (char.IsPunctuation(c))
                            typeDelayMs = Functions.Getrandom.NextDouble() * (_punctuationPauseMax - _punctuationPauseMin) + _punctuationPauseMin;
                        if (Functions.Getrandom.NextDouble() < _thinkingPauseProbability)
                            await Task.Delay((int)(Functions.Getrandom.NextDouble()*1000) + 500);
                        if (Functions.Getrandom.NextDouble() < _errorProbability)
                        {
                            char nearbyChar = GetRandomNearbyChar(c);
                            Console.Write(nearbyChar);
                            await Task.Delay((int)(Functions.Getrandom.NextDouble() * 200 + 100));
                            Console.Write("\b \b");
                            await Task.Delay((int)typeDelayMs);
                        }
                            Console.Write(c);
                            i++;
                            await Task.Delay((int)typeDelayMs);
                        if (i == text.Length)
                        {
                            _toSkip = true;
                            break;
                        }
                    }
                    else
                    {
                        Console.Write(c);
                        i++;
                    }
                }
            Console.WriteLine();
        }
    }


    private static double GaussianRandom(double mean, double stdDev)
    {
        double u1 = 1.0 - Functions.Getrandom.NextDouble();
        double u2 = 1.0 - Functions.Getrandom.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
        return Math.Max(0, mean + stdDev * randStdNormal); 
    }
    private static char GetRandomNearbyChar(char original)
    {
        string nearbyRus = "йцукенгшщзхъфывапролджэячсмитьбю";
        string nearbyEng = "qwertyuiopasdfghjklzxcvbnm";
        char lowerOriginal = char.ToLower(original);
        if (nearbyRus.Contains(lowerOriginal))
        {
            int index = nearbyRus.IndexOf(lowerOriginal);
            int newIndex = index + (Functions.Getrandom.Next(3) - 1); 
            newIndex = Math.Clamp(newIndex, 0, nearbyRus.Length - 1);
            return nearbyRus[newIndex];
        }
        else if (nearbyEng.Contains(lowerOriginal))
        {
            int index = nearbyEng.IndexOf(lowerOriginal);
            int newIndex = index + (Functions.Getrandom.Next(3) - 1); 
            newIndex = Math.Clamp(newIndex, 0, nearbyEng.Length - 1);
            return nearbyEng[newIndex];
        }
        else{
            return original; // Если символ не в окрестности, возвращаем его как есть
        }
    }
}

using System.Data.Common;

namespace DragonCave;

public class UILib
{
    private static readonly double _baseDelayMean = 50; // Средняя задержка между символами (мс)
    private static readonly double _baseDelayStdDev = 30; // Стандартное отклонение для задержки
    private static readonly double _wordPauseMin = 200; // Мин. пауза после пробела (мс)
    private static readonly double _wordPauseMax = 300; // Макс. пауза после пробела
    private static readonly double _punctuationPauseMin = 200; // Мин. пауза после знаков препинания
    private static readonly double _punctuationPauseMax = 30; // Макс. пауза после знаков
    private static readonly double _thinkingPauseProbability = 0.05; // Вероятность "размышления"
    private static readonly double _errorProbability = 0.02; // Вероятность ошибки

    public static async Task TypeWriterEffectAsync(string text, int typeDelayMs = 100, int eraseDelayMs = 50)
    {
        
        Console.CursorVisible = true;
        foreach (char c in text)
        {
            Console.Write(c);
            await Task.Delay(typeDelayMs);
        }
        Console.WriteLine();
        Console.ReadKey(intercept: true);
        for (int i = text.Length; i > 0; i--)
        {
            Console.Write("\b \b");
            await Task.Delay(eraseDelayMs);
        }
    }
    public static async Task TypeWriterEffect(string text, int typeDelayMsMin = 10, int typeDelayMax = 200, bool EnterToContinue = false)
    {
        char? prevChar = null;
        Console.CursorVisible = true;
        foreach (char c in text)
        {
            double typeDelayMs = GaussianRandom(_baseDelayMean, _baseDelayStdDev);
            if (prevChar == c)
                typeDelayMs *= 0.5;
            if (char.IsWhiteSpace(c))
                typeDelayMs = Functions.Getrandom.NextDouble() * (_wordPauseMax - _wordPauseMin) + _wordPauseMin;
            if (char.IsPunctuation(c))
                typeDelayMs = Functions.Getrandom.NextDouble() * (_punctuationPauseMax - _punctuationPauseMin) + _punctuationPauseMin;
            if (Functions.Getrandom.NextDouble() < _thinkingPauseProbability)
                await Task.Delay((int)Functions.Getrandom.NextDouble()*1000 + 500);
            if (Functions.Getrandom.NextDouble() < _errorProbability)
            {
                char nearbyChar = GetRandomNearbyChar(c);
                Console.Write(nearbyChar);
                await Task.Delay((int)(Functions.Getrandom.NextDouble() * 200 + 100));
                Console.Write("\b \b");
                await Task.Delay((int)typeDelayMs);
            }
            Console.Write(c);
            await Task.Delay((int)typeDelayMs);
        }
        Console.WriteLine();
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
        // Простая заглушка: возвращаем случайную букву из окрестности
        string nearbyRus = "йцукенгшщзхъфывапролджэячсмитьбю";
        string nearbyEng = "qwertyuiopasdfghjklzxcvbnm";
        if (!nearbyRus.Contains(char.ToLower(original)) || !nearbyEng.Contains(char.ToLower(original)))
            return original;
        int index1 = nearbyRus.IndexOf(char.ToLower(original));
        int index2 = nearbyEng.IndexOf(char.ToLower(original));
        int newIndex1 = index1 + (Functions.Getrandom.Next(3) - 1); // Смещение на -1, 0 или +1
        int newIndex2 = index2 + (Functions.Getrandom.Next(3) - 1); // Смещение на -1, 0 или +1
        newIndex1 = Math.Clamp(newIndex1, 0, nearbyRus.Length - 1);
        newIndex2 = Math.Clamp(newIndex2, 0, nearbyEng.Length - 1);
        if (!nearbyRus.Contains(char.ToLower(original)))
            return nearbyRus[newIndex1];
        if (!nearbyEng.Contains(char.ToLower(original)))
            return nearbyEng[newIndex2];
        return original;
    }
}  
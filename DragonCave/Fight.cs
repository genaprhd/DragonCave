namespace DragonCave;

public class Fight
{
    public static int Battle(int Move1, int Move2)
    {
        int Winner = 0;
        if (Move1 == 1)
        {
            if (Move2 == 1)
            {
                
            }
        }
        return 0;
    }
    
    public static int MakeATurn(string Name, int option, bool isBot)
    {
        if (isBot == false)
        {
            Thread.Sleep(2000);
            Console.WriteLine(" Make your move!\n 1. Attack (5-15 damage)\n 2. Block (3-5 damage)\n Your answer: ");
            option = Functions.GetOption();
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
}